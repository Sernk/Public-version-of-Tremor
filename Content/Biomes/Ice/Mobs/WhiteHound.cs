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
	public class WhiteHound : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("White Hound");
			Main.npcFrameCount[NPC.type] = 10;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 200;
			NPC.damage = 45;
			NPC.defense = 10;
			NPC.knockBackResist = 0.1f;
			NPC.width = 62;
			NPC.height = 32;
			AnimationType = 329;
			NPC.aiStyle = 26;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit6;
			NPC.DeathSound = SoundID.NPCDeath5;
			NPC.value = Item.buyPrice(silver: 5, copper: 3);
		}

        public override void HitEffect(NPC.HitInfo hitInfo)
        {
            if (NPC.life <= 0)
            {
                for (int k = 0; k < 20; k++)
				{
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitInfo.HitDirection, -2.5f, 0, default(Color), 0.7f);
                }
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("WhiteHoundGore1").Type, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("WhiteHoundGore2").Type, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("WhiteHoundGore2").Type, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("WhiteHoundGore2").Type, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("WhiteHoundGore3").Type, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("WhiteHoundGore3").Type, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("WhiteHoundGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("WhiteHoundGore3").Type, 1f);
            }
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {

            // 5% шанс выпадения IceBlockB
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(),
                ModContent.ItemType<IceBlockB>(), 5, 1, 4));

            // 10% шанс выпадения Icicle
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(),
                ModContent.ItemType<Icicle>(), 10, 1, 3));
        }      

		public override void ModifyHitPlayer(Player target, ref Player.HurtModifiers modifiers)
		{
			if (Main.hardMode || Main.expertMode)
			{
				target.AddBuff(BuffID.Frostburn, Main.rand.Next(1, 3) * 60);
			}
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
                Main.hardMode &&
                !NPC.AnyNPCs(NPCID.LunarTowerVortex) &&
                !NPC.AnyNPCs(NPCID.LunarTowerStardust) &&
                !NPC.AnyNPCs(NPCID.LunarTowerNebula) &&
                !NPC.AnyNPCs(NPCID.LunarTowerSolar))
            {
                return 15f;
            }

            return 0f;
        }
    }
}