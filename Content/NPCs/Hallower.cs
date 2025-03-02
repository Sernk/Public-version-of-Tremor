using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs
{
	public class Hallower : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Hallower");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 5000;
			NPC.damage = 150;
			NPC.defense = 70;
			NPC.knockBackResist = 0.1f;
			NPC.width = 40;
			NPC.height = 40;
			AnimationType = 121;
			NPC.aiStyle = 14;
			AIType = 75;
			NPC.noGravity = true;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.buffImmune[20] = true;
			NPC.buffImmune[24] = true;
			NPC.buffImmune[39] = true;
			NPC.buffImmune[31] = false;
			NPC.DeathSound = SoundID.NPCDeath7;
			NPC.value = Item.buyPrice(0, 0, 5, 0);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<HallowerBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

		public override void OnKill()
		{
			if (Main.rand.NextBool(1))
			{
				Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.PixieDust, 5);
			}
		}

        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
			}
		}

		public override void AI()
		{
			if (Main.rand.NextBool(6))
				Main.dust[Dust.NewDust(NPC.position, NPC.width, NPC.height, 55, 0f, 0f, 200, NPC.color)].velocity *= 0.3f;
			if (Main.rand.Next(40) == 0)
				SoundEngine.PlaySound(SoundID.Pixie, NPC.position);
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && NPC.downedMoonlord && Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.Player.ZoneHallow && spawnInfo.SpawnTileY < Main.worldSurface ? 0.01f : 0f;
	}
}