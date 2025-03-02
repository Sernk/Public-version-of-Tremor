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
	public class MightyNimbus : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Mighty Nimbus");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 4000;
			NPC.damage = 160;
			NPC.defense = 70;
			NPC.knockBackResist = 0.1f;
			NPC.width = 70;
			NPC.height = 50;
			AnimationType = 250;
			NPC.aiStyle = 49;
			AIType = 250;
			NPC.noGravity = true;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit30;
			NPC.buffImmune[20] = true;
			NPC.buffImmune[24] = true;
			NPC.buffImmune[39] = true;
			NPC.buffImmune[31] = false;
			NPC.DeathSound = SoundID.NPCDeath33;
			NPC.value = Item.buyPrice(0, 0, 7, 0);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<MightyNimbusBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 54, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 54, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 54, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 54, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);

				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 76, 0f, 0f, 200, NPC.color, 1f);
			}
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                NPC.NewNPC(NPC.GetSource_Death(), (int)NPC.position.X - 50, (int)NPC.position.Y, NPCID.AngryNimbus);
                NPC.NewNPC(NPC.GetSource_Death(), (int)NPC.position.X + 50, (int)NPC.position.Y, NPCID.AngryNimbus);
            }
        }

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && NPC.downedMoonlord && Helper.NoZoneAllowWater(spawnInfo) && Main.raining && spawnInfo.SpawnTileY < Main.worldSurface ? 0.01f : 0f;
	}
}