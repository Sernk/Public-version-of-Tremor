using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Vanity;

namespace TremorMod.Content.NPCs
{
	public class MagiumSword : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Magium Sword");
			Main.npcFrameCount[NPC.type] = 6;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 30;
			NPC.damage = 30;
			Main.npcFrameCount[NPC.type] = 6;
			NPC.defense = 24;
			NPC.knockBackResist = 0f;
			NPC.width = 34;
			NPC.height = 34;
			AnimationType = 84;
			NPC.aiStyle = 23;
			NPC.noGravity = true;
			NPC.npcSlots = 15f;
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = Item.buyPrice(0, 0, 0, 0);
		}

		public override void AI()
		{
			if (Main.rand.NextBool(6))
				Main.dust[Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, 0f, 0f, 200, NPC.color, 2f)].velocity *= 0.3f;
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
			}
		}
	}
}