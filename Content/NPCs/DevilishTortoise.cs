using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Placeable.Banners;

namespace TremorMod.Content.NPCs
{
	public class DevilishTortoise : ModNPC
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Devil Tortoise");
			Main.npcFrameCount[NPC.type] = 8;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 400;
			NPC.damage = 90;
			NPC.defense = 32;
			NPC.knockBackResist = 0f;
			NPC.width = 64;
			NPC.height = 48;
			NPC.lavaImmune = true;
			AnimationType = 153;
			NPC.aiStyle = 39;
			NPC.npcSlots = 2f;
			NPC.HitSound = SoundID.NPCHit2;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.value = Item.buyPrice(0, 0, 8, 9);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<DevilishTortoiseBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0) 
            {
                int hitDirection = hit.HitDirection; 

                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
                }

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("DevilishTortoiseGore").Type, 1f);
            }
            else 
            {
                for (int k = 0; k < hit.Damage / NPC.lifeMax * 50; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, hit.HitDirection, -1f, 0, default(Color), 0.7f);
                }
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.hardMode && spawnInfo.SpawnTileY > Main.maxTilesY - 200 ? 0.10f : 0;
        }
    }
}