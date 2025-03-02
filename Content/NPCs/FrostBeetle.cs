using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Materials;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs
{
	public class FrostBeetle : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Frost Beetle");
			Main.npcFrameCount[NPC.type] = 6;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 3000;
			NPC.damage = 150;
			NPC.defense = 72;
			NPC.knockBackResist = 0.1f;
			NPC.width = 40;
			NPC.height = 40;
			AnimationType = 508;
			NPC.aiStyle = 3;
			AIType = 508;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit41;
			NPC.buffImmune[20] = true;
			NPC.buffImmune[24] = true;
			NPC.buffImmune[39] = true;
			NPC.buffImmune[31] = false;
			NPC.DeathSound = SoundID.NPCDeath44;
			NPC.value = Item.buyPrice(0, 0, 12, 0);
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<FrostBeetleBanner>();
			ItemID.Sets.KillsToBanner[BannerItem] = 50;
		}

		public override void OnKill()
		{
            if (Main.rand.NextBool(5))
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.SnowBlock);
            }
            if (Main.rand.NextBool(5))
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.IceBlock);
            }
            if (Main.rand.NextBool(3))
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<FrostCore>());
            }
            if (NPC.downedMoonlord && Main.rand.NextBool(5))
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<IceSoul>());
            }
        }

		public override void HitEffect(NPC.HitInfo hit)
		{
			
			int hitDirection = hit.HitDirection;

			if (NPC.life <= 0)
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("IBGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("IBGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("IBGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("IBGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("IBGore2").Type, 1f);
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.6f);
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Main.hardMode && NPC.downedMoonlord && spawnInfo.Player.ZoneSnow && spawnInfo.SpawnTileY > Main.rockLayer ? 0.01f : 0f;
	}
}