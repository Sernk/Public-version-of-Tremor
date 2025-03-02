using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.NPCsDrop;

namespace TremorMod.Content.NPCs
{
	public class DesertMimic : ModNPC
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Desert Mimic");
			Main.npcFrameCount[NPC.type] = 14;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 3500;
			NPC.damage = 90;
			NPC.defense = 34;
			NPC.knockBackResist = 0f;
			NPC.width = 48;
			NPC.height = 40;
			NPC.aiStyle = 87;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = Item.buyPrice(0, 3, 0, 0);
			AnimationType = NPCID.BigMimicHallow;
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AntlionFury>(), 4));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Hurricane>(), 4));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SandShuriken>(), 4));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CrawlerHook>(), 4));
            npcLoot.Add(ItemDropRule.Common(ItemID.GreaterManaPotion, 1, 1, 10));
            npcLoot.Add(ItemDropRule.Common(ItemID.GreaterHealingPotion, 1, 1, 10));
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            bool normalSpawn = !spawnInfo.PlayerInTown; // Пример условия нормального спавна.
            bool noZoneAllowWater = !spawnInfo.Player.ZoneDungeon && !spawnInfo.Player.ZoneCorrupt && !spawnInfo.Player.ZoneCrimson;

            // Условия для спауна в подземной пустыне в хардмоде
            bool inUndergroundDesert = spawnInfo.Player.ZoneDesert && spawnInfo.SpawnTileY > Main.rockLayer;

            return normalSpawn && (spawnInfo.SpawnTileType == 53 || spawnInfo.SpawnTileType == 112 || spawnInfo.SpawnTileType == 116 || spawnInfo.SpawnTileType == 234)
                && noZoneAllowWater && spawnInfo.Water && Main.hardMode && inUndergroundDesert
                && (spawnInfo.SpawnTileX < 250 || spawnInfo.SpawnTileX > Main.maxTilesX - 250) && !spawnInfo.PlayerSafe
                ? 0.01f : 0f;
        }
    }
}