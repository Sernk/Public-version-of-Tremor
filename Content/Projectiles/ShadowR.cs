using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Dusts;

namespace TremorMod.Content.Projectiles
{
	public class ShadowR : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 12;
			Projectile.height = 12;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 25;
			Projectile.timeLeft = 120;
			Projectile.aiStyle = 1;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = false;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Shadow Reaper");

		}

		int time2 = 6;
		int time = 6;

		public override void AI()
		{
			float max_dist = 300f;
			int ID = -1;
			float min_dist = float.MaxValue;
			if (time > 0)
			{
				time--;
			}
			for (int k = 0; k < Main.npc.Length; k++)
			{
				if (!Main.npc[k].friendly && Main.npc[k].active && Vector2.Distance(Projectile.position, Main.npc[k].position) < min_dist)
				{
					min_dist = Vector2.Distance(Projectile.position, Main.npc[k].position);
					ID = k;
				}
			}
			float smooth = 12f;
			if (ID != -1 && min_dist <= max_dist && time == 0)
			{
				NPC npc = Main.npc[ID];
				Vector2 From = Projectile.position;
				Vector2 To = npc.position;
				float Speed = 15f;
				Vector2 Move = (To - From);
				Vector2 Vel = Move * (Speed / (float)Math.Sqrt(Move.X * Move.X + Move.Y * Move.Y));
				Projectile.velocity = Projectile.velocity + ((Vel - Projectile.velocity) / smooth);
				if (Vector2.Distance(Projectile.position, Main.npc[ID].position) < 30f && time2 > 0)
					time2--;
				else if (Vector2.Distance(Projectile.position, Main.npc[ID].position) < 30f)
				{
					Projectile.Kill();
				}
			}
			CreateDust();
		}

		public override void OnKill(int timeLeft)
		{
			for (int k = 0; k < 17; k++)
			{
				int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<DustV>(), Projectile.oldVelocity.X * 0.7f, Projectile.oldVelocity.Y * 0.7f);
			}
			SoundEngine.PlaySound(SoundID.NPCDeath7, Projectile.position);
		}

		public void CreateDust()
		{
			if (Main.rand.NextBool(2))
			{
				int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<DustV>());
				Main.dust[dust].scale = 0.9f;
			}
		}
	}
}
