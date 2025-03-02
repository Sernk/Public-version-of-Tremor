using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;

namespace TremorMod.Content.NPCs
{
	public class DreadBeetle : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Dread Beetle");
			Main.npcFrameCount[NPC.type] = 6;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 1800;
			NPC.damage = 150;
			NPC.defense = 30;
			NPC.knockBackResist = 0.6f;
			NPC.width = 38;
			NPC.height = 44;
			AnimationType = 258;
			NPC.aiStyle = 3;
			AIType = 258;
			NPC.npcSlots = 0.2f;
			NPC.HitSound = SoundID.NPCHit45;
			NPC.DeathSound = SoundID.NPCDeath47;
			NPC.value = Item.buyPrice(0, 0, 8, 24);
			NPC.noGravity = false;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<DreadBeetleBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

        public override void OnKill()
        {
            if (Main.rand.NextBool(2))
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<Doomstone>());
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
				for(int i = 0; i < 2; ++i)
            Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("DreadGore1").Type, 1f);
            Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("DreadGore2").Type, 1f);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.hardMode && NPC.downedMoonlord && !spawnInfo.Player.ZoneDungeon && spawnInfo.SpawnTileY > Main.rockLayer ? 0.10f : 0f;
        }
    }
}