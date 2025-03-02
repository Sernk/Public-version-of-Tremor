using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Placeable.Banners;

namespace TremorMod.Content.NPCs
{
	public class Dinictis : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Dinichthys");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 800;
			NPC.damage = 95;
			NPC.defense = 20;
			NPC.knockBackResist = 0.3f;
			NPC.width = 34;
			NPC.height = 48;
			AnimationType = 65;
			NPC.aiStyle = 16;
			NPC.npcSlots = 1f;
			NPC.HitSound = SoundID.NPCHit31;
			NPC.noGravity = true;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = Item.buyPrice(0, 0, 7, 9);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<DinictisBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
                int hitDirection = hit.HitDirection;
                for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				for (int i = 0; i < 3; ++i)
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("DinictisGore1").Type, 1f);
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("DinictisGore2").Type, 1f);
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("DinictisGore3").Type, 1f);
			}
        }

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Sharking>(), 35));
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.tileSand[spawnInfo.SpawnTileType] && spawnInfo.Water && Main.hardMode && spawnInfo.SpawnTileY < Main.rockLayer && (spawnInfo.SpawnTileX < 250 || spawnInfo.SpawnTileX > Main.maxTilesX - 250) && !spawnInfo.PlayerSafe ? 0.10f : 0f;
        }
    }
}