using System;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using TremorMod.Content.Projectiles;
using Terraria.DataStructures;
using TremorMod.Content.NPCs.Bosses;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.CyberKing;

namespace TremorMod.Content.NPCs.Bosses
{
    [AutoloadBossHead]
    public class CyberKing : ModNPC
    {
        private int attackPhase = 0; // Текущая фаза атаки
        private int attackCooldown = 0; // Задержка между атаками


        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cyber King");
			Main.npcFrameCount[npc.type] = 6;
		}*/

        public override void HitEffect(NPC.HitInfo hitInfo)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CyberKingGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CyberKingGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CyberKingGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CyberKingGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CyberKingGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CyberKingGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CyberKingGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CyberKingGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CyberKingGore3").Type, 1f);
            }
        }

        public override void SetDefaults()
        {
            NPC.aiStyle = -1;
            NPC.lifeMax = 60000;
            NPC.damage = 80;
            NPC.defense = 65;
            NPC.knockBackResist = 0f;
            NPC.width = 316;
            NPC.height = 314;
            NPC.value = Item.buyPrice(0, 20, 0, 0);
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath6;
            Music = MusicID.Boss2;
            //BossBag = ModContent.ItemType<CyberKingBag>();
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 6; // Количество кадров
            NPCID.Sets.MPAllowedEnemies[Type] = true;
            NPCID.Sets.BossBestiaryPriority.Add(Type);
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
        }


        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++; // Увеличиваем счетчик кадров
            if (NPC.frameCounter >= 10) // Скорость смены кадров (чем больше число, тем медленнее анимация)
            {
                NPC.frameCounter = 0; // Сбрасываем счётчик
                NPC.frame.Y += frameHeight; // Переключаем кадр

                // Если кадры закончились, возвращаемся к первому
                if (NPC.frame.Y >= Main.npcFrameCount[NPC.type] * frameHeight)
                {
                    NPC.frame.Y = 0;
                }
            }
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float bossLifeScale, float balance)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * bossLifeScale);
            NPC.damage = (int)(NPC.damage * 0.6f);
        }

        public override void AI()
        {
            Player player = Main.player[NPC.target];

            if (!player.active || player.dead)
            {
                NPC.TargetClosest(false);
                if (!player.active || player.dead)
                {
                    NPC.velocity.Y += 0.1f;
                    if (NPC.timeLeft > 10)
                    {
                        NPC.timeLeft = 10;
                    }
                    return;
                }
            }

            // Move in infinity symbol
            NPC.ai[0] += 0.02f; // Speed of movement
            float centerX = player.Center.X;
            float centerY = player.Center.Y - 200f;
            float amplitudeX = 150f; // Width of infinity symbol
            float amplitudeY = 100f; // Height of infinity symbol

            Vector2 targetPosition = new Vector2(
                centerX + amplitudeX * (float)Math.Sin(NPC.ai[0]),
                centerY + amplitudeY * (float)Math.Sin(2 * NPC.ai[0])
            );

            // Ensure boss maintains a minimum distance from the player
            float distanceToPlayer = Vector2.Distance(targetPosition, player.Center);
            if (distanceToPlayer < 400f) // Minimum distance increased
            {
                targetPosition += (targetPosition - player.Center).SafeNormalize(Vector2.Zero) * (400f - distanceToPlayer);
            }

            NPC.Center = targetPosition;

            // Attack logic
            if (attackCooldown > 0)
            {
                attackCooldown--;
            }
            else
            {
                switch (attackPhase)
                {
                    case 0: // Central barrage
                        for (int i = 0; i < 16; i++) // 8 снарядов в круговом направлении
                        {
                            Vector2 velocity = new Vector2(6f, 0f).RotatedBy(MathHelper.TwoPi * i / 16);
                            Projectile.NewProjectileDirect(
                                NPC.GetSource_FromAI(),
                                NPC.Center,
                                velocity,
                                ModContent.ProjectileType<PurplePulsePro>(),
                                20,
                                0f,
                                Main.myPlayer
                            );
                        }
                        break;

                    case 1: // Summon Cybermite
                        for (int i = 0; i < 4; i++)
                        {
                            NPC.NewNPC(
                                NPC.GetSource_FromAI(),
                                (int)(NPC.Center.X + 100 * Math.Cos(MathHelper.TwoPi * i / 4)),
                                (int)(NPC.Center.Y + 100 * Math.Sin(MathHelper.TwoPi * i / 4)),
                                ModContent.NPCType<Cybermite>()
                            );
                        }
                        break;

                    case 2: // Homing projectiles
                        int[] durations = { 420, 240, 120 };
                        float[] speeds = { 4f, 8f, 12f };

                        for (int i = 0; i < 3; i++)
                        {
                            Projectile proj = Projectile.NewProjectileDirect(
                                NPC.GetSource_FromAI(),
                                NPC.Center,
                                (player.Center - NPC.Center).SafeNormalize(Vector2.UnitX) * speeds[i],
                                ModContent.ProjectileType<CyberRingPro>(),
                                60,
                                0f,
                                Main.myPlayer
                            );
                            proj.timeLeft = durations[i];
                        }
                        break;
                }

                attackPhase = (attackPhase + 1) % 3;
                attackCooldown = 180; // Delay between attacks
            }
        }

        public override void OnKill()
        {
            IEntitySource source = NPC.GetSource_Death();
            // Пометка босса как убитого
            //TremorWorld.Boss.CyberKing.Downed();
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            // Выпадение обычных предметов
            npcLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 1, 6, 25)); // 6-25 золотых монет
            npcLoot.Add(ItemDropRule.Common(ItemID.SilverCoin, 1, 6, 25)); // 6-25 серебряных монет

            // Выпадение трофея с шансом 10%
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CyberKingTrophy>(), 10));

            // Выпадение маски с шансом 1/7 (14.29%) вне экспертного режима
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<CyberKingMask>(), 7));

            // Гарантированное выпадение одного из трёх предметов.
            npcLoot.Add(ItemDropRule.OneFromOptions(1,
                ModContent.ItemType<RedStorm>(),
                ModContent.ItemType<CyberCutter>(),
                ModContent.ItemType<ShockwaveClaymore>()));

            // Добавление предмета для экспертного режима с 100% шансом.
            //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CyberKingBag>(), 1)); // 100% шанс выпадения

            // Альтернативное использование условия:
             npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<CyberKingBag>(), 1));
        }
    }
}
