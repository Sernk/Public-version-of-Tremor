using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Biomes.Ice.Items;

namespace TremorMod.Content.Biomes.Ice.Mobs
{
	public class Dot : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Coldtrap");
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = Main.hardMode ? 300 : 30;
			NPC.damage = Main.hardMode ? 65 : 25;
			//Main.npcFrameCount[npc.type] = 4;
			NPC.defense = 0;
			NPC.knockBackResist = 0.3f;
			NPC.width = 78;
			NPC.height = 54;
			//animationType = 3;
			NPC.aiStyle = 0;
			NPC.npcSlots = 1f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 10, 5);
		}

		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */
		{
			NPC.lifeMax = NPC.lifeMax * 1;
			NPC.damage = NPC.damage * 1;
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            // Проверка, находится ли координата в пределах карты
            if (spawnInfo.SpawnTileX < 0 || spawnInfo.SpawnTileX >= Main.maxTilesX ||
                spawnInfo.SpawnTileY < 0 || spawnInfo.SpawnTileY >= Main.maxTilesY)
            {
                return 0f;
            }

            // Список допустимых тайлов
            int[] allowedTiles = {
                Mod.Find<ModTile>("IceOre").Type,
                Mod.Find<ModTile>("IceBlock").Type,
                Mod.Find<ModTile>("VeryVeryIce").Type,
                Mod.Find<ModTile>("DungeonBlock").Type
            };

            // Проверяем наличие тайла и дополнительные условия
            if (allowedTiles.Contains(Main.tile[spawnInfo.SpawnTileX, spawnInfo.SpawnTileY].TileType) &&
                !NPC.AnyNPCs(NPCID.LunarTowerVortex) &&
                !NPC.AnyNPCs(NPCID.LunarTowerStardust) &&
                !NPC.AnyNPCs(NPCID.LunarTowerNebula) &&
                !NPC.AnyNPCs(NPCID.LunarTowerSolar))
            {
                return 15f;
            }

            return 0f;
        }


        public override void AI()
        {
            if (NPC.localAI[0] == 0f)
            {
                int damage = Main.hardMode ? 40 : 15;

                // Создаем источник для вызова снарядов
                IEntitySource source = NPC.GetSource_FromAI();

                for (int k = 1; k < 5; k++)
                {
                    // Центр NPC как стартовая позиция
                    Vector2 position = NPC.Center;
                    Vector2 velocity = Vector2.Zero; // Скорость нулевая

                    // Создаем снаряд
                    int proj = Projectile.NewProjectile(source, position, velocity, Mod.Find<ModProjectile>("ColdtrapChain").Type, damage, 0, Main.myPlayer);

                    // Проверяем успешность создания снаряда
                    if (proj >= Main.maxProjectiles)
                    {
                        NPC.active = false;
                        return;
                    }

                    // Работаем с созданным снарядом
                    ColdtrapChain arm = Main.projectile[proj].ModProjectile as ColdtrapChain;
                    if (arm != null)
                    {
                        arm.arm = NPC.whoAmI;
                        arm.width = 16f;
                        arm.length = ColdtrapChain.minLength;
                        arm.minAngle = (k - 0.05f) * (float)Math.PI / 3f;
                        arm.maxAngle = (k + 0.25f) * (float)Math.PI / 3f;
                    }

                    Main.projectile[proj].rotation = (arm.minAngle + arm.maxAngle) / 3f;
                    Main.projectile[proj].netUpdate = true;
                }

                NPC.localAI[0] = 1f;
            }

            base.AI();
        }

        public override void OnKill()
        {

            IEntitySource source = NPC.GetSource_FromAI();
            Vector2 bossCenter = NPC.Center;

            int cyberKingID = ModContent.NPCType<Glacier>();
            NPC.NewNPC(source, (int)bossCenter.X, (int)bossCenter.Y, cyberKingID, 0, 0, 0, 0, 0, NPC.target);

            Player player = Main.player[NPC.target];
            SoundEngine.PlaySound(SoundID.Roar, player.position);
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
			if (Main.hardMode || Main.expertMode)
			{
				target.AddBuff(BuffID.Frostburn, 180);
			}
		}
	}
}