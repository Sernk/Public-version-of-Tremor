using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.NPCsDrop;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs
{
	public class OceanMimic : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ocean Mimic");
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
        public override void OnKill()
        {
            if (Main.rand.NextBool())
            {
                Item.NewItem(NPC.GetSource_Loot(), NPC.position, ItemID.GreaterHealingPotion, Main.rand.Next(1, 10));
                Item.NewItem(NPC.GetSource_Loot(), NPC.position, ItemID.GreaterManaPotion, Main.rand.Next(1, 10));

            }
            if (Main.rand.NextFloat() < 0.25f)
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<TrueTrident>());
            }
            if (Main.rand.NextFloat() < 0.25f)
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<TheTide>());
            }
            if (Main.rand.NextFloat() < 0.25f)
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<SharkRage>());
            }
            if (Main.rand.NextFloat() < 0.25f)
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<OceanAmulet>());
            }
            if (Main.rand.NextFloat() < 0.25f)
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<SquidTentacle>());
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            bool normalSpawn = !spawnInfo.PlayerInTown; // Пример условия нормального спавна.
            bool noZoneAllowWater = !spawnInfo.Player.ZoneDungeon && !spawnInfo.Player.ZoneCorrupt && !spawnInfo.Player.ZoneCrimson;

            return normalSpawn && (spawnInfo.SpawnTileType == 53 || spawnInfo.SpawnTileType == 112 || spawnInfo.SpawnTileType == 116 || spawnInfo.SpawnTileType == 234)
                && noZoneAllowWater && spawnInfo.Water && Main.hardMode && spawnInfo.SpawnTileY < Main.rockLayer
                && (spawnInfo.SpawnTileX < 250 || spawnInfo.SpawnTileX > Main.maxTilesX - 250) && !spawnInfo.PlayerSafe
                ? 0.01f : 0f;
        }

    }
}