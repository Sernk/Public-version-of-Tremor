using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Dusts;

namespace TremorMod.Content.NPCs.Invasion.ParadoxTitan
{
	public class Hand_ : ModNPC
	{
		//[1] id head

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Paradox Titan Hand");
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 40000;
			NPC.damage = 100;
			NPC.defense = 50;
			NPC.knockBackResist = 0.5f;
			NPC.width = 44;
			NPC.height = 84;
			NPC.aiStyle = 12;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath14;
			NPC.value = Item.buyPrice(0, 0, 5, 0);
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{

			}
		}
		public override bool PreKill()
		{
			NPC.aiStyle = -1;
			NPC.ai[1] = -1;
			return false;
		}
	}
}