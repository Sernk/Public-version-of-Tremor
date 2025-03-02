using TremorMod.Content.Items.Placeable.Banners;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using System.IO;

namespace TremorMod.Content.NPCs
{
	public class Crimer : ModNPC
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Crimer");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 250;
			NPC.damage = 70;
			NPC.defense = 12;
			NPC.knockBackResist = 0.5f;
			NPC.width = 40;
			NPC.height = 40;
			AnimationType = 121;
			NPC.aiStyle = 14;
			NPC.noGravity = true;
			NPC.npcSlots = 0.7f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = Item.buyPrice(0, 0, 5, 0);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<CrimerBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
				int hitDirection = NPC.direction;

				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

			}
		}

        public override void OnKill()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                NPC.NewNPC(NPC.GetSource_Loot(), (int)NPC.position.X, (int)NPC.position.Y, NPCID.Crimslime);
            }
        }
    }
}