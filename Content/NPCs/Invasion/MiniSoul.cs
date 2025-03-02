using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Dusts;
using TremorMod.Content.Event;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Weapons.Melee;

namespace TremorMod.Content.NPCs.Invasion
{
	public class MiniSoul : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Paradox Soul");
			Main.npcFrameCount[NPC.type] = 3;
		}

		int num;
		public readonly IList<int> targets = new List<int>();
		public static readonly int arenaWidth = (int)(1.3f * NPC.sWidth);
		public static readonly int arenaHeight = (int)(1.3f * NPC.sHeight);
		public override void SetDefaults()
		{
			NPC.lifeMax = 450;
			NPC.damage = 150;
			NPC.defense = 30;
			NPC.knockBackResist = 0f;
			NPC.width = 28;
			NPC.height = 30;
			NPC.aiStyle = 87;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath42;
			NPC.value = Item.buyPrice(0, 3, 0, 0);
			AnimationType = 3;
		}

		public override void OnKill()
		{

		}

		private void SettingNumber()
		{
			if (Main.rand.NextBool(2))
			{
				num++;
			}

			else
			{
				num--;
			}
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 10; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<CyberDust>(), 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}

				CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>();
				if (InvasionWorld.CyberWrath && Main.rand.NextBool(4))
				{
					InvasionWorld.CyberWrathPoints1 += 1;
					//Main.NewText(("Wave 1: Complete " + TremorWorld.CyberWrathPoints + "%"), 39, 86, 134);
				}
			}

			for (int k = 0; k < hit.Damage / NPC.lifeMax * 50.0; k++)
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<CyberDust>(), hitDirection, -1f, 0, default(Color), 0.7f);
			}
		}
	}
}