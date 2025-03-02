using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs
{
	public class IronGiant : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Iron Giant");
			Main.npcFrameCount[NPC.type] = 10;
		}

		public override void SetDefaults()
		{
			NPC.width = 40;
			NPC.height = 60;
			NPC.damage = 31;
			NPC.defense = 30;
			NPC.lifeMax = 800;
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = Item.buyPrice(0, 0, 28, 7);
			NPC.knockBackResist = 0.3f;
			NPC.aiStyle = 3;
			AIType = 343;
			AnimationType = 343;
			NPC.buffImmune[20] = true;
			NPC.buffImmune[31] = false;
			NPC.buffImmune[24] = true;
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<IronGiantBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

        public override void OnKill()
        {
            if (Main.rand.NextBool(8))
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<ElectricSpear>());
            }
            if (Main.rand.NextBool(10))
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.DepthMeter);
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
            {
                for (int k = 0; k < 20; k++)
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 31, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("IGGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("IGGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("IGGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("IGGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("IGGore4").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("IGGore4").Type, 1f);
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> (Helper.NoZoneAllowWater(spawnInfo)) && Main.hardMode && spawnInfo.SpawnTileY > Main.rockLayer ? 0.001f : 0f;
	}
}
