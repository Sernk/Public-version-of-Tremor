using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Biomes.Ice.Items;

namespace TremorMod.Content.Biomes.Ice.Mobs
{
	public class WhiteWalker : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("White Walker");
			Main.npcFrameCount[NPC.type] = 3;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = Main.hardMode ? 300 : 30;
			NPC.damage = Main.hardMode ? 55 : 12;
			NPC.defense = Main.hardMode ? 13 : 2;
			NPC.knockBackResist = 0.3f;
			NPC.width = 56;
			NPC.height = 48;
			AnimationType = 3;
			NPC.aiStyle = 3;
			NPC.npcSlots = 1f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(silver: 15, copper: 5);
		}

		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */
		{
			NPC.lifeMax += 10 * numPlayers;
			NPC.damage += 3 * numPlayers;
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
                Main.dayTime &&
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
			NPC.spriteDirection = NPC.direction;
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            // Шанс выпадения Frostex (3.33%, 1 из 30)
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<IceCross>(), 25));

            // 10% шанс выпадения IceBlockB
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(),
                ModContent.ItemType<IceBlockB>(), 10, 1, 4));

            // 5% шанс выпадения Icicle
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(),
                ModContent.ItemType<Icicle>(), 20, 1, 3));
        }

        public override void ModifyHitPlayer(Player target, ref Player.HurtModifiers modifiers)
		{
			if (Main.hardMode || Main.expertMode)
			{
				target.AddBuff(BuffID.Frostburn, Main.rand.Next(1, 3) * 60);
			}
		}

        public override void HitEffect(NPC.HitInfo hitInfo)
        {
            if (NPC.life <= 0)
            {
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitInfo.HitDirection, -2.5f, 0, default(Color), 0.7f);
                }
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("WhiteWalkerGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("WhiteWalkerGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("WhiteWalkerGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("WhiteWalkerGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("WhiteWalkerGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("WhiteWalkerGore3").Type, 1f);
			}
		}
	}
}