using System.IO;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Dusts;

namespace TremorMod.Content.NPCs.Invasion.ParadoxTitan
{
	public class TitanCrystal : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Paradox Crystal");
			Main.npcFrameCount[NPC.type] = 5;
		}

		public override void SetDefaults()
		{
			AnimationType = 523;
			NPC.npcSlots = 0.3f;
			NPC.damage = 150;
			NPC.width = 36;
			NPC.height = 38;
			NPC.scale = 0.8f;
			NPC.defense = 45;
			NPC.lifeMax = 9500;
			NPC.knockBackResist = 0f;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.value = Item.buyPrice(0, 0, 0, 0);
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
		}

		public override bool PreAI()
		{
			bool expertMode = Main.expertMode;
			NPC.TargetClosest(true);
			Vector2 direction = Main.player[NPC.target].Center - NPC.Center;
			direction.Normalize();
			direction *= 9f;
			NPC.rotation = 0f;
			Player player = Main.player[NPC.target];
			NPC parent = Main.npc[NPC.FindFirstNPC(Mod.Find<ModNPC>("Titan").Type)];
			double deg = (double)NPC.ai[1] / 2;
			double rad = deg * (Math.PI / 180);
			double dist = 250;
			NPC.position.X = parent.Center.X - (int)(Math.Cos(rad) * dist) - NPC.width / 2;
			NPC.position.Y = parent.Center.Y - (int)(Math.Sin(rad) * dist) - NPC.height / 2;
			NPC.ai[1] += 2f;
			return false;
		}

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float bossLifeScale, float balance)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * bossLifeScale);
            NPC.damage = (int)(NPC.damage * 0.6f);
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            for (int k = 0; k < 5; k++)
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<CyberDust>(), hitDirection, -1f, 0, default(Color), 1f);
			}
		}

		public override bool CheckActive()
		{
			return false;
		}
	}
}