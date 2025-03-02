using System;
using System.Collections.Generic;
using System.IO;
using ReLogic.Content;
using ReLogic.Utilities;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.Localization;
using Filters = Terraria.Graphics.Effects.Filters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using TremorMod.Content.Items;
using TremorMod.Content.Items.HeaterOfWorldsItems;

namespace TremorMod.Content.NPCs.Bosses
{
    public abstract class HeaterofWorldsPart : ModNPC
    {
        public bool JustSpawned
        {
            get { return NPC.localAI[0] == 0f; }
            set { NPC.localAI[0] = value ? 0f : 1f; }
        }

        public NPC PrevSegment => Main.npc[(int)NPC.ai[1]];

        public NPC ParentHead => Main.npc[(int)NPC.ai[2]];

        public override void SetDefaults()
        {
            NPC.lifeMax = 6500;
            NPC.damage = 39;
            NPC.defense = 40;
            NPC.aiStyle = 6;
            NPC.npcSlots = 5f;
            NPC.knockBackResist = 0f;

            Music = 17;

            NPC.noTileCollide = true;
            NPC.behindTiles = true;
            NPC.friendly = false;
            NPC.noGravity = true;
            NPC.dontTakeDamage = false;
            NPC.dontCountMe = true;
            NPC.lavaImmune = true;
            NPC.buffImmune[BuffID.OnFire] = true;
            NPC.buffImmune[BuffID.Burning] = true;

            NPC.HitSound = SoundID.NPCHit7;
            NPC.DeathSound = SoundID.NPCDeath10;
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float bossLifeScale, float balance)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * bossLifeScale);
            NPC.damage = (int)(NPC.damage * 0.6f);
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            if (Main.expertMode || Main.rand.NextBool())
            {
                target.AddBuff(BuffID.OnFire, 180); // Применяет эффект "Горение" на 60 кадров.
            }
        }

        /*public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D drawTexture = Main.NPCTexture[NPC.type];
            Vector2 origin = new Vector2(drawTexture.Width / 2f, drawTexture.Height / Main.npcFrameCount[NPC.type] / 2f);

            Vector2 drawPos = NPC.Center - Main.screenPosition;
            SpriteEffects effects = NPC.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

            spriteBatch.Draw(drawTexture, drawPos, NPC.frame, lightColor, NPC.rotation, origin, NPC.scale, effects, 0);

            return false;
        }*/

        public void CheckSegments()
        {
            if (!PrevSegment.active || !ParentHead.active)
            {
                // Perform hit effect without VanillaHitEffect
                NPC.HitEffect();  // Trigger NPC hit effect

                // Handle NPC death
                NPC.life = 0;
                NPC.timeLeft = 0;
                NPC.active = false;
            }
        }

    }

    [AutoloadBossHead]
	public class HeaterOfWorldsHead : HeaterofWorldsPart
	{
		/*public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			NPCID.Sets.TechnicallyABoss[NPC.type] = false;
		}*/

		public override void SetDefaults()
		{
			base.SetDefaults();
            NPC.width = 74;
            NPC.height = 82;

            NPC.boss = true;
		}

		public override void AI()
		{
			SegmentBody();
			UpdatePosition();
			UpdateVelocity();
			SpawnAdds();
		}

        private void SpawnAdds()
        {
            int odds = Main.expertMode ? 430 : 490;

            if (Main.rand.NextBool(odds))
            {
                // Create an entity source and spawn the new NPC
                IEntitySource source = NPC.GetSource_FromAI();  // Get the source from the current NPC AI

                NPC.NewNPC(source, (int)NPC.Center.X - 70, (int)NPC.Center.Y, ModContent.NPCType<MagmaLeechHead>());
            }
        }


        private void UpdatePosition()
		{
            NPC.position += NPC.velocity;
		}

		private void UpdateVelocity()
		{
			if ((int)(Main.time % 180) == 0)
			{
				float from = NPC.AngleFrom(Main.player[NPC.target].Center);
                NPC.velocity = new Vector2((float)Math.Cos(from), (float)Math.Sin(from)) * -7;
                NPC.netUpdate = true;
			}
		}

        private void SegmentBody()
        {
            if (JustSpawned)
            {
                int previous = NPC.whoAmI;
                const int segments = 25;

                for (int i = 0; i < segments; i++)
                {
                    int type =
                        i < segments - 1
                            ? ModContent.NPCType<HeaterOfWorldsBody>()
                            : ModContent.NPCType<HeaterOfWorldsTail>();

                    // Get the entity source for spawning the NPC
                    IEntitySource source = NPC.GetSource_FromAI(); // This gets the source from the current NPC's AI context

                    // Create the new segment NPC
                    int segmentWhoAmI = NPC.NewNPC(source, (int)NPC.Center.X, (int)NPC.Center.Y, type, ai1: previous, ai2: NPC.whoAmI);
                    NPC segment = Main.npc[segmentWhoAmI];
                    segment.whoAmI = segmentWhoAmI;
                    segment.realLife = NPC.whoAmI;
                    segment.active = true;
                    previous = segmentWhoAmI;
                }

                JustSpawned = false;
            }
        }


        /*private void ConvertTiles()
        {
            Point16 center = NPC.Center.ToTileCoordinates16();
            int halfLength = NPC.width / 2 / 16 + 1;

            for (int x = center.X - halfLength; x <= center.X + halfLength; x++)
            {
                for (int y = center.Y - halfLength; y <= center.Y + halfLength; y++)
                {
                    Tile tile = Main.tile[x, y];

                    // Check if the tile is on the boundary and inactive
                    if ((x == center.X - halfLength
                        || x == center.X + halfLength
                        || y == center.Y - halfLength
                        || y == center.Y + halfLength)
                        && !tile.active())
                    {
                        tile.type = TileID.ObsidianBrick;
                        tile.active() = true;  // Set active as true (not a method call)
                    }

                    tile.lava(false);  // Remove lava
                    tile.liquid = 0;  // Set liquid level to 0

                    // Send the tile change over the network (for servers)
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendTileSquare(-1, x, y, 1);
                    }
                    else
                    {
                        WorldGen.SquareTileFrame(x, y);
                    }
                }
            }
        }*/


        public override void OnKill()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                // Создаем квадрат с лутом
                SpawnLootBox();
            }

            IEntitySource source = NPC.GetSource_Death();
            // Пометка босса как убитого
            // TremorWorld.Boss.HeaterofWorlds.Downed();
        }

        private void SpawnLootBox()
        {
            // Определяем размеры и центр квадрата
            int width = 10; // ширина квадрата (включая границы)
            int height = 10; // высота квадрата (включая границы)
            int centerX = (int)(NPC.Center.X / 16); // переводим координаты в тайлы
            int centerY = (int)(NPC.Center.Y / 16);

            int halfWidth = width / 2;
            int halfHeight = height / 2;

            // Проходим по каждому блоку в квадрате
            for (int x = -halfWidth; x <= halfWidth; x++)
            {
                for (int y = -halfHeight; y <= halfHeight; y++)
                {
                    int tileX = centerX + x;
                    int tileY = centerY + y;

                    Tile tile = Main.tile[tileX, tileY];
                    if (tile != null)
                    {
                        // Удаляем жидкость в блоке
                        tile.LiquidAmount = 0; // Устанавливаем уровень жидкости в 0
                        WorldGen.SquareTileFrame(tileX, tileY); // Обновляем блок для отображения
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendTileSquare(-1, tileX, tileY, 1); // Синхронизация для мультиплеера
                        }
                    }

                    // Устанавливаем блоки только на границах
                    if (x == -halfWidth || x == halfWidth || y == -halfHeight || y == halfHeight)
                    {
                        // Устанавливаем обсидиановый кирпич (ID: 56)
                        WorldGen.PlaceTile(tileX, tileY, TileID.ObsidianBrick);
                    }
                    else
                    {
                        // Удаляем блоки внутри квадрата (если есть)
                        WorldGen.KillTile(tileX, tileY);
                    }
                }
            }

            // Спавним сундук в центре квадрата
            int chestIndex = WorldGen.PlaceChest(centerX, centerY, style: 0); // style: 0 - деревянный сундук
            if (chestIndex >= 0)
            {
                Chest chest = Main.chest[chestIndex];
                if (chest != null)
                {
                    // Добавляем лут в сундук
                    chest.item[0].SetDefaults(ItemID.HealingPotion); // зелье лечения
                    chest.item[0].stack = 10;

                    chest.item[1].SetDefaults(ItemID.GoldCoin); // золотые монеты
                    chest.item[1].stack = 5;
                }
            }
        }





        public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
            npcLoot.Add(ItemDropRule.Common(ItemID.ManaPotion, 1, 5, 20)); 
            npcLoot.Add(ItemDropRule.Common(ItemID.HealingPotion, 1, 6, 20)); 

            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<MoltenParts>(), 1, 1));

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HeaterOfWorldsTrophy>(), 10));

            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType <HeaterOfWorldsMask> (), 7));

            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<HeaterOfWorldsBag> (), 1));

		}
	}
}