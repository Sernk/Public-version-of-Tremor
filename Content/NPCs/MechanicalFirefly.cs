using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs
{
	public class MechanicalFirefly : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Mechanical Firefly");
			Main.npcFrameCount[NPC.type] = 9;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 3000;
			NPC.damage = 115;
			NPC.defense = 46;
			NPC.knockBackResist = 0.1f;
			NPC.width = 58;
			NPC.height = 36;
			AnimationType = 509;
			NPC.aiStyle = 44;
			NPC.noGravity = true;
			AIType = 509;
			NPC.npcSlots = 0.4f;
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = Item.buyPrice(0, 0, 40, 7);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<MechanicalFireflyBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 61, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 61, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 62, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 62, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 63, 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && NPC.downedMoonlord && Main.hardMode && Main.bloodMoon && spawnInfo.SpawnTileY < Main.worldSurface ? 0.007f : 0f;
	}
}