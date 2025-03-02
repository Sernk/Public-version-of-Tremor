using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.NPCs.Bosses.TikiTotem
{
	public class TikiSoulPro : ModProjectile
	{
		//private const float length = 2400f;

		public override void SetDefaults()
		{

			Projectile.width = 48;
			Projectile.height = 48;
			Projectile.hostile = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
			CooldownSlot = 1;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Tiki Soul");

		}

		public override void AI()
		{
			Projectile.localAI[0] += 1f;
			if (Projectile.localAI[0] > 3f)
			{
				for (int num449 = 0; num449 < 4; num449++)
				{
					Vector2 vector34 = Projectile.position;
					vector34 -= Projectile.velocity * (num449 * 0.25f);
					Projectile.alpha = 255;
					int num450 = Dust.NewDust(vector34, 1, 1, 62, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num450].position = vector34;
					Dust expr_13F6C_cp_0 = Main.dust[num450];
					expr_13F6C_cp_0.position.X = expr_13F6C_cp_0.position.X + Projectile.width / 2;
					Dust expr_13F90_cp_0 = Main.dust[num450];
					expr_13F90_cp_0.position.Y = expr_13F90_cp_0.position.Y + Projectile.height / 2;
					Main.dust[num450].scale = Main.rand.Next(70, 110) * 0.013f;
					Main.dust[num450].velocity *= 0.2f;
				}
			}
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].Hitbox.Intersects(Projectile.Hitbox))
				{
					if (Main.npc[k].type == Mod.Find<ModNPC>("TikiTotem").Type)
					{
						Projectile.Kill();
					}
				}
			}
		}
	}
}