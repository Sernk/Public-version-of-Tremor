using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Weapons.Ranged;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Placeable;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Bag;
using TremorMod.Content.Tiles;
using TremorMod;
using TremorMod.Utilities;
// босс существует осталось исправить руки

namespace TremorMod.Content.NPCs.Bosses.WallofShadows
{
    [AutoloadBossHead]
    public class WallOfShadow : ModNPC
    {
        public int phase = 1;
        private int frameCounter = 0;
        private int frame = 0;
        public int wofF = 0;


        public int wallOfShadowIndex = -1;
        public int wallOfShadowBottom = -1;
        public int wallOfShadowTop = -1;
        private const int ShootRate = 70;
        private const int ShootDamage = 15;
        private const float ShootKnockback = 1;
        private float _shootSpeed = 20;
        private const bool Shoots = true;
        private int _timeToShoot = ShootRate;
        private const float DistortPercent = 0.15f;

        private int MagicBoltCooldown
        {
            get { return (int)NPC.ai[2]; }
            set { NPC.ai[2] = value; }
        }

        private int LaserCooldown
        {
            get { return (int)NPC.ai[0]; }
            set { NPC.ai[0] = value; }
        }

        public override void SetDefaults()
        {
            NPC.width = 100;
            NPC.height = 100;
            NPC.value = Item.buyPrice(0, 17, 0, 0);
            NPC.damage = 64;
            NPC.defense = 57;
            NPC.lifeMax = 36000;
            NPC.knockBackResist = 0f;
            NPC.npcSlots = 10;
            NPC.boss = true;
            NPC.scale = 1.2f;
            NPC.noGravity = true;
            NPC.lavaImmune = true;
            NPC.behindTiles = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit8;
            NPC.DeathSound = SoundID.NPCDeath10;
            Music = MusicID.Boss4;
            //WallofShadowBag
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 4;
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float bossLifeScale, float balance)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * bossLifeScale);
            NPC.damage = (int)(NPC.damage * 0.6f);
        }

        public override void ModifyHitPlayer(Player target, ref Player.HurtModifiers modifiers)
        {
            if (Main.expertMode)
            {
                target.AddBuff(BuffID.ShadowFlame, 240);
            }
        }

        private void ShootBall()
        {
            MagicBoltCooldown--;
            if (MagicBoltCooldown <= 60 && MagicBoltCooldown % ((Main.expertMode) ? 12 : 20) == 0 && Main.netMode != 1)
            {
                var targetPos = NPC.HasPlayerTarget ? Main.player[NPC.target].Center : Main.npc[NPC.target].Center;
                var shootPos = (NPC.Top + new Vector2(0, 60)).RotatedBy(NPC.rotation, NPC.Center);
                float inaccuracy = 3f * (NPC.life / NPC.lifeMax);
                var shootVel = targetPos - shootPos + new Vector2(Main.rand.NextFloat(-inaccuracy, inaccuracy), Main.rand.NextFloat(-inaccuracy, inaccuracy));
                shootVel.Normalize();
                shootVel *= 10f;
                Projectile.NewProjectile(NPC.GetSource_FromThis(), shootPos, shootVel, 290, NPC.damage, 5f, Main.myPlayer);
            }
            if (MagicBoltCooldown <= 0)
            {
                MagicBoltCooldown = 100 + (int)(60 * (float)NPC.life / NPC.lifeMax);
            }
        }

        private void Shoot()
        {
            if (--_timeToShoot > 0) //если таймер меньше нуля, то вырубаем автоматом
                return;
            _timeToShoot = (int)Helper.DistortFloat(ShootRate, DistortPercent); //устанавливаем частоту выстрела
            for (int i = 0; i < ((Main.expertMode) ? 3 : 1); i++) //в цикле указываем кол-во перьев при выстреле
            {
                if (Main.expertMode)
                {
                    _shootSpeed = 25;
                }
                Vector2 velocity = Helper.VelocityToPoint(NPC.Center, Helper.RandomPointInArea(new Vector2(Main.player[NPC.target].Center.X - 10, Main.player[NPC.target].Center.Y - 10), new Vector2(Main.player[NPC.target].Center.X + 20, Main.player[NPC.target].Center.Y + 20)), _shootSpeed); //здесь устанавливаем позиции (здесь от перса в плеера)
                int proj = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center.X, NPC.Center.Y, velocity.X, velocity.Y, 83, (int)Helper.DistortFloat(ShootDamage, DistortPercent), Helper.DistortFloat(ShootKnockback, DistortPercent)); //подтверждаем все выше действие: от перса к мобу, от моба к персу (второе выстрел)
                Main.projectile[proj].Center = NPC.Center;
            }
        }

        private void ShootSuper()
        {
            LaserCooldown--;
            if (LaserCooldown <= 60 && LaserCooldown % ((Main.expertMode) ? 4 : 7) == 0 && Main.netMode != 1)
            {
                Vector2 velocity = Helper.VelocityToPoint(NPC.Center, Helper.RandomPointInArea(new Vector2(Main.player[NPC.target].Center.X - 100, Main.player[NPC.target].Center.Y - 100), new Vector2(Main.player[NPC.target].Center.X + 20, Main.player[NPC.target].Center.Y + 20)), ((Main.expertMode) ? 20 : 15)); //здесь устанавливаем позиции (здесь от перса в плеера)
                int proj = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center.X, NPC.Center.Y, velocity.X, velocity.Y, 83, (int)Helper.DistortFloat(ShootDamage, DistortPercent), Helper.DistortFloat(ShootKnockback, DistortPercent)); //подтверждаем все выше действие: от перса к мобу, от моба к персу (второе выстрел)
                Main.projectile[proj].Center = NPC.Center;
            }
            if (LaserCooldown <= 0)
            {
                LaserCooldown = 100 + (int)(600 * (float)NPC.life / NPC.lifeMax);
            }
        }

        public override void AI()
        {
            float targetY = (float)(Main.worldSurface * 16 + 200);

            if (NPC.position.Y > targetY + 10)
                NPC.velocity.Y = -1.5f;
            else if (NPC.position.Y < targetY - 10)
                NPC.velocity.Y = 1.5f;
            else
                NPC.velocity.Y = 0.0f;

            float speed = CalculateSpeed();

            if (NPC.velocity.X == 0.0f)
            {
                NPC.TargetClosest(true);
                NPC.velocity.X = NPC.direction;
            }

            NPC.velocity.X = NPC.direction * speed;

            NPC.TargetClosest(false);
            if (NPC.target != -1)
            {
                Player player = Main.player[NPC.target];
                NPC.position.Y = player.position.Y;
                player.AddBuff(22, 1);
                if (player.dead)
                {
                    HandlePlayerDeath();
                }
            }

            ShootBall();
            ShootSuper();

            if (NPC.life < NPC.lifeMax * 0.5f)
            {
                HandlePhase2();
            }

            HandleBuffs();
            HandleAnimation();
        }

        private float CalculateSpeed()
        {
            float speed = 2.0f;

            if (NPC.life < NPC.lifeMax * 0.75)
                speed += 0.25f;
            if (NPC.life < NPC.lifeMax * 0.5)
                speed += 0.4f;
            if (NPC.life < NPC.lifeMax * 0.25)
                speed += 0.5f;
            if (NPC.life < NPC.lifeMax * 0.1)
                speed += 0.6f;

            if (Main.expertMode)
            {
                if (NPC.life < NPC.lifeMax * 0.66)
                    speed += 0.3f;
                if (NPC.life < NPC.lifeMax * 0.33)
                    speed += 0.3f;
                if (NPC.life < NPC.lifeMax * 0.05)
                    speed += 0.6f;
                if (NPC.life < NPC.lifeMax * 0.035)
                    speed += 0.6f;
                if (NPC.life < NPC.lifeMax * 0.025)
                    speed += 0.6f;

                speed = speed * 1.35f + 0.35f;
            }

            return speed;
        }

        private void HandlePlayerDeath()
        {
            NPC.TargetClosest(false);
            NPC.velocity.Y = NPC.velocity.Y + 1f;
            if (NPC.position.Y > Main.worldSurface * 16.0)
            {
                NPC.velocity.Y = NPC.velocity.Y + 1f;
            }
            if (NPC.position.Y > Main.rockLayer * 16.0)
            {
                for (int num957 = 0; num957 < 200; num957++)
                {
                    if (Main.npc[num957].aiStyle == NPC.aiStyle)
                    {
                        Main.npc[num957].active = false;
                    }
                }
            }
        }

        private void HandlePhase2()
        {
            TextureAssets.NpcHeadBoss[NPCID.Sets.BossHeadTextures[NPC.type]] = ModContent.Request<Texture2D>("TremorMod/Content/NPCs/Bosses/WallofShadows/WallOfShadow_Head_Boss1");

            Shoot();

            if ((int)(Main.time % 360) == 0)
            {
                SpawnShadowSteed();
            }

            int wallOfShadowIndex = NPC.FindFirstNPC(ModContent.NPCType<WallOfShadow>());
            if (wallOfShadowIndex < 0)
            {
                NPC.active = false;
                return;
            }

            NPC.ai[1]++;
            if (NPC.ai[2] == 0)
            {
                if (NPC.life < NPC.lifeMax * 0.5F)
                    NPC.ai[1]++;
                if (NPC.life < NPC.lifeMax * 0.2F)
                    NPC.ai[1]++;
                if (NPC.ai[1] > 2700.0)
                    NPC.ai[2] = 1f;
            }

            if (NPC.ai[2] > 0 && NPC.ai[1] > 60)
            {
                int spawnCooldown = 3;
                if (NPC.life < NPC.lifeMax * 0.3)
                    ++spawnCooldown;
                NPC.ai[2]++;
                NPC.ai[1] = 0;
                if (NPC.ai[2] > spawnCooldown)
                    NPC.ai[2] = 0;

                SpawnShadowSteed();
            }

            HandleTileChecks();
        }

        private void SpawnShadowSteed()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                int index = NPC.NewNPC(Entity.GetSource_FromThis(), (int)(NPC.position.X + (NPC.width / 2)), (int)(NPC.position.Y + (NPC.height / 2) + 20.0),
                    ModContent.NPCType<ShadowSteed>(), 1, 0.0f, 0.0f, 0.0f, 0.0f, byte.MaxValue);
                Main.npc[index].velocity.X = NPC.direction * 6;
            }
        }

        private void HandleTileChecks()
        {
            int npcTileX = (int)(NPC.position.X / 16);
            int npcRightXTile = (int)((NPC.position.X + NPC.width) / 16);
            int npcCenterYTile = (int)((NPC.position.Y + (NPC.height / 2)) / 16);

            int npcBottom = GetSolidTiles(npcTileX, npcRightXTile, npcCenterYTile + 7, 1);
            int num5 = npcBottom + 4;

            if (wallOfShadowBottom == -1)
                wallOfShadowBottom = num5 * 16;
            else if (wallOfShadowBottom > num5 * 16)
            {
                --wallOfShadowBottom;
                if (wallOfShadowBottom < num5 * 16)
                    wallOfShadowBottom = num5 * 16;
            }
            else if (wallOfShadowBottom < num5 * 16)
            {
                ++wallOfShadowBottom;
                if (wallOfShadowBottom > num5 * 16)
                    wallOfShadowBottom = num5 * 16;
            }

            int num7 = GetSolidTiles(npcTileX, npcRightXTile, npcCenterYTile - 7, -1) - 4;

            if (wallOfShadowTop == -1)
                wallOfShadowTop = num7 * 16;
            else if (wallOfShadowTop > num7 * 16)
            {
                --wallOfShadowTop;
                if (wallOfShadowTop < num7 * 16)
                    wallOfShadowTop = num7 * 16;
            }
            else if (wallOfShadowTop < num7 * 16)
            {
                ++wallOfShadowTop;
                if (wallOfShadowTop > num7 * 16)
                    wallOfShadowTop = num7 * 16;
            }
        }

        private int GetSolidTiles(int startX, int endX, int startY, int step)
        {
            int solidTiles = 0;
            int y = startY;
            while (solidTiles < 15 && y > Main.maxTilesY - 200)
            {
                y += step;
                for (int i = startX; i <= endX; ++i)
                {
                    try
                    {
                        if (WorldGen.SolidTile(i, y) || Main.tile[i, y].LiquidAmount > 0)
                        {
                            ++solidTiles;
                        }
                    }
                    catch
                    {
                        solidTiles += 15;
                    }
                }
            }
            return y;
        }

        private void HandleBuffs()
        {
            for (int i = 0; i < 255; ++i)
            {
                if (Main.player[i].active && !Main.player[i].dead)
                {
                    if ((Main.player[i].Center.X > NPC.Center.X && Main.player[i].direction == -1 && NPC.direction == -1) ||
                        (Main.player[i].Center.X < NPC.Center.X && Main.player[i].direction == 1 && NPC.direction == 1))
                    {
                        if (Vector2.Distance(Main.player[i].Center, NPC.Center) <= 480f)
                        {
                            Main.player[i].AddBuff(BuffID.TheTongue, 600);
                        }
                    }
                }
            }
        }

        private void HandleAnimation()
        {
            int previousPhase = phase;

            if (NPC.life < NPC.lifeMax * 0.5)
            {
                phase = 2;
            }

            if (previousPhase != phase)
            {
                frameCounter = 0;
                frame = (phase == 1) ? 0 : 2;
            }

            AnimateNPC();
        }

        private void AnimateNPC()
        {
            frameCounter++;
            if (frameCounter >= 30)
            {
                frameCounter = 0;

                if (phase == 1)
                {
                    frame = (frame == 0) ? 1 : 0;
                }
                else if (phase == 2)
                {
                    frame = (frame == 2) ? 3 : 2;
                }
            }
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.frame.Y = frame * frameHeight;
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                for (int i = 1; i <= 27; i++)
                {
                    float x =
                          i <= 2 ? 1f
                        : i <= 8 ? 2f
                        : i <= 18 ? 3f
                        : i <= 26 ? 4f
                        : 5f;
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, x);
                }

                for (int i = 1; i <= 13; i++)
                {
                    int x = i <= 2 ? 1 : 2;
                    //Gore.NewGore(NPC.position, NPC.velocity, Mod.GetGoreSlot("Gores/WallOfShadowGore" + x));
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("WallOfShadowGore1").Type, x);
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("WallOfShadowGore2").Type, x);
                }
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {

            Texture2D shadowChain = ModContent.Request<Texture2D>("TremorMod/Content/NPCs/Bosses/WallofShadows/WallOfShadowChain").Value;
            Texture2D shadowWall = ModContent.Request<Texture2D>("TremorMod/Content/NPCs/Bosses/WallofShadows/WallOfShadow_Wall").Value;

            for (int i = 0; i < 255; i++)
            {
                if (Main.player[i].active && Main.player[i].tongued && !Main.player[i].dead)
                {
                    float num = NPC.position.X + (NPC.width / 2);
                    float num2 = NPC.position.Y + (NPC.height / 2);
                    Vector2 vector = new Vector2(Main.player[i].position.X + Main.player[i].width * 0.5f, Main.player[i].position.Y + Main.player[i].height * 0.5f);
                    float num3 = num - vector.X;
                    float num4 = num2 - vector.Y;
                    float rotation = (float)Math.Atan2(num4, num3) - 1.57f;
                    bool flag = true;
                    while (flag)
                    {
                        float num5 = (float)Math.Sqrt(num3 * num3 + num4 * num4);
                        if (num5 < 40f)
                        {
                            flag = false;
                        }
                        else
                        {
                            num5 = shadowChain.Height / num5;
                            num3 *= num5;
                            num4 *= num5;
                            vector.X += num3;
                            vector.Y += num4;
                            num3 = num - vector.X;
                            num4 = num2 - vector.Y;
                            Color color = Lighting.GetColor((int)vector.X / 16, (int)(vector.Y / 16f));
                            spriteBatch.Draw(shadowChain, new Vector2(vector.X - Main.screenPosition.X, vector.Y - Main.screenPosition.Y), new Rectangle(0, 0, shadowChain.Width, shadowChain.Height), color, rotation, new Vector2(shadowChain.Width * 0.5f, shadowChain.Height * 0.5f), 1f, SpriteEffects.None, 0f);
                        }
                    }
                }
            }
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].active && Main.npc[j].type == ModContent.NPCType<ShadowHand>())
                {
                    float num6 = NPC.position.X + (NPC.width / 2);
                    float num7 = NPC.position.Y;
                    float num8 = (wallOfShadowBottom - wallOfShadowTop);
                    bool flag2 = Main.npc[j].frameCounter > 7.0;
                    num7 = wallOfShadowTop + num8 * Main.npc[j].ai[0];
                    Vector2 vector2 = new Vector2(Main.npc[j].position.X + (Main.npc[j].width / 2), Main.npc[j].position.Y + (Main.npc[j].height / 2));
                    float num9 = num6 - vector2.X;
                    float num10 = num7 - vector2.Y;
                    float rotation2 = (float)Math.Atan2(num10, num9) - 1.57f;
                    bool flag3 = true;
                    while (flag3)
                    {
                        SpriteEffects effects1 = SpriteEffects.None;
                        if (flag2)
                        {
                            effects1 = SpriteEffects.FlipHorizontally;
                            flag2 = false;
                        }
                        else
                        {
                            flag2 = true;
                        }
                        int height = 28;
                        float num11 = (float)Math.Sqrt(num9 * num9 + num10 * num10);
                        if (num11 < 40f)
                        {
                            height = (int)num11 - 40 + 28;
                            flag3 = false;
                        }
                        num11 = 28f / num11;
                        num9 *= num11;
                        num10 *= num11;
                        vector2.X += num9;
                        vector2.Y += num10;
                        num9 = num6 - vector2.X;
                        num10 = num7 - vector2.Y;
                        Color color2 = Lighting.GetColor((int)vector2.X / 16, (int)(vector2.Y / 16f));
                        spriteBatch.Draw(shadowChain, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle(0, 0, shadowChain.Width, height), color2, rotation2, new Vector2(shadowChain.Width * 0.5f, shadowChain.Height * 0.5f), 1f, effects1, 0f);
                    }
                }
            }
            int num12 = 140;
            float num13 = wallOfShadowTop;
            float num14 = wallOfShadowBottom;
            num14 = Main.screenPosition.Y + Main.screenHeight;
            float num15 = (int)((num13 - Main.screenPosition.Y) / num12) + 1;
            num15 *= num12;
            if (num15 > 0f)
            {
                num13 -= num15;
            }
            float num16 = num13;
            float num17 = NPC.position.X;
            float num18 = num14 - num13;
            bool flag4 = true;
            SpriteEffects effects2 = SpriteEffects.None;
            if (NPC.spriteDirection == 1)
            {
                effects2 = SpriteEffects.FlipHorizontally;
            }
            if (NPC.direction > 0)
            {
                num17 -= 80f;
            }
            int num19 = 0;
            if (!Main.gamePaused)
            {
                wofF++;
            }
            if (wofF > 12)
            {
                num19 = 280;
                if (wofF > 17)
                {
                    wofF = 0;
                }
            }
            else if (wofF > 6)
            {
                num19 = 140;
            }
            while (flag4)
            {
                num18 = num14 - num16;
                if (num18 > num12)
                {
                    num18 = num12;
                }
                bool flag5 = true;
                int num20 = 0;
                while (flag5)
                {
                    int x = (int)(num17 + shadowWall.Width / 2) / 16;
                    int y = (int)(num16 + num20) / 16;
                    Main.spriteBatch.Draw(shadowWall, new Vector2(num17 - Main.screenPosition.X, num16 + num20 - Main.screenPosition.Y), new Rectangle(0, num19 + num20, shadowWall.Width, 16), Lighting.GetColor(x, y), 0f, default(Vector2), 1f, effects2, 0f);
                    num20 += 16;
                    if (num20 >= num18)
                    {
                        flag5 = false;
                    }
                }
                num16 += num12;
                if (num16 >= num14)
                {
                    flag4 = false;
                }
            }

            Texture2D drawTexture = TextureAssets.Npc[NPC.type].Value;
            Vector2 origin = new Vector2((drawTexture.Width / 2) * 0.5F, (drawTexture.Height / Main.npcFrameCount[NPC.type]) * 0.5F);

            Vector2 drawPos = new Vector2(
            NPC.position.X - Main.screenPosition.X + (NPC.width / 2) - (TextureAssets.Npc[NPC.type].Value.Width / 2) * NPC.scale / 2f + origin.X * NPC.scale,
            NPC.position.Y - Main.screenPosition.Y + NPC.height - TextureAssets.Npc[NPC.type].Value.Height * NPC.scale / Main.npcFrameCount[NPC.type] + 4f + origin.Y * NPC.scale + NPC.gfxOffY);

            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(drawTexture, drawPos, NPC.frame, drawColor, NPC.rotation, origin, NPC.scale, effects, 0);

            return false;
        }

        public override void OnKill()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                SpawnLootBox();
            }

            IEntitySource source = NPC.GetSource_Death();
        }

        private void SpawnLootBox()
        {
           
            int width = 20; 
            int height = 20; 
            int centerX = (int)(NPC.Center.X / 16); 
            int centerY = (int)(NPC.Center.Y / 16);

            int halfWidth = width / 2;
            int halfHeight = height / 2;

            for (int x = -halfWidth; x <= halfWidth; x++)
            {
                for (int y = -halfHeight; y <= halfHeight; y++)
                {
                    int tileX = centerX + x;
                    int tileY = centerY + y;

                    Tile tile = Main.tile[tileX, tileY];
                    if (tile != null)
                    {
                        tile.LiquidAmount = 0;
                        WorldGen.SquareTileFrame(tileX, tileY); 
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendTileSquare(-1, tileX, tileY, 1); 
                        }
                    }

                    if (x == -halfWidth || x == halfWidth || y == -halfHeight || y == halfHeight)
                    {
                        WorldGen.PlaceTile(tileX, tileY, TileID.Demonite);
                    }
                    else
                    {
                        WorldGen.KillTile(tileX, tileY);
                    }
                }
            }            
        }



        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WallofShadowTrophy>(), 10));
            npcLoot.Add(ItemDropRule.Common(ItemID.GreaterHealingPotion, 1, 5, 15));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WallofShadowMask>(), 7));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DarknessCloth>(), 1, 8, 15));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<WallofShadowBag>(), 1));

            // Гарантированное выпадение одного из трёх предметов.
            npcLoot.Add(ItemDropRule.OneFromOptions(1,
                ModContent.ItemType<HeavyBeamCannon>(),
                ModContent.ItemType<Bolter>(),
                ModContent.ItemType<StrikerBlade>()));
        }
    }
}