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
using TremorMod.Content.Event;

namespace TremorMod.Content.NPCs.Invasion.ParadoxTitan
{
	[AutoloadBossHead]
	public class Titan_ : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Titan Soul");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public static readonly int arenaWidth = (int)(1.3f * NPC.sWidth);
		public override void SetDefaults()
		{
			NPC.aiStyle = 94;
			NPC.lifeMax = 1;
			NPC.dontTakeDamage = true;
			NPC.defense = 15;
			NPC.knockBackResist = 0f;
			NPC.width = 108;
			NPC.height = 98;
			NPC.value = Item.buyPrice(0, 20, 0, 0);
			NPC.npcSlots = 15f;
			NPC.lavaImmune = true;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
		}

		int CurrentFrame;
		int TimeToAnimation = 6;
		const int AnimationRate = 6;
		bool FirstState_ = true;
		void Animation()
		{
			if (--TimeToAnimation <= 0)
			{

				if (++CurrentFrame > 4)
					CurrentFrame = 1;
				TimeToAnimation = AnimationRate;
				NPC.frame = GetFrame(CurrentFrame + ((FirstState_) ? 0 : 4));
			}
		}

		Rectangle GetFrame(int Number)
		{
			return new Rectangle(0, NPC.frame.Height * (Number - 1), NPC.frame.Width, NPC.frame.Height);
		}

		public override void HitEffect(NPC.HitInfo hit)
		{

		}

		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			return false;
		}

		public override void AI()
		{
			Player player = Main.player[Main.myPlayer];
			if (NPC.Distance(Main.player[NPC.target].position) > 5000)
			{
				player.position = NPC.Center;
			}
			Animation();
			CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>();
			if (InvasionWorld.CyberWrath && InvasionWorld.CyberWrathPoints1 == 97)
			{
				NPC.dontTakeDamage = false;
				NPC.life = 0;
				NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X, (int)NPC.position.Y, Mod.Find<ModNPC>("Titan").Type);
				InvasionWorld.CyberWrathPoints1 = 98;
			}

			if (InvasionWorld.CyberWrath && InvasionWorld.CyberWrathPoints1 < 98)
				NPC.dontTakeDamage = true;
			bool FirstAttack = true;
			if (FirstAttack)
			{
				SetupCrystals(arenaWidth / 2, false);
				FirstAttack = false;
			}

			if (player.dead)
			{
				NPC.active = true;
			}

			if (player.statLife == 0)
			{
				player.position = NPC.Center;
			}
		}

		private void SetupCrystals(int radius, bool clockwise)
		{
			if (Main.netMode == 1)
			{
				return;
			}
			Vector2 center = NPC.Center;
			for (int k = 0; k < 15; k++)
			{
				float angle = 2f * (float)Math.PI / 10f * k;
				Vector2 pos = center + radius * new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
				int damage = 80;
				if (Main.expertMode)
				{
					damage = (int)(100 / Main.GameModeInfo.EnemyDamageMultiplier);
				}
				int proj = Projectile.NewProjectile(NPC.GetSource_FromThis(), pos.X, pos.Y, 0f, 0f, Mod.Find<ModProjectile>("TitanCrystal_").Type, damage, 0f, Main.myPlayer, NPC.whoAmI, angle);
				Main.projectile[proj].localAI[0] = radius;
				Main.projectile[proj].localAI[1] = clockwise ? 1 : -1;
				//NetMessage.SendData(27, -1, -1, "", proj);
			}
		}
	}
}