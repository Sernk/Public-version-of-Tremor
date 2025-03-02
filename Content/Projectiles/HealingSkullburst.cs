using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Projectiles
{
	public class HealingSkullburst : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.timeLeft = 420;
			Projectile.width = 52;
			Projectile.height = 52;
			Projectile.friendly = true;
			Main.projFrames[Projectile.type] = 12;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (Main.LocalPlayer.HasBuff(Mod.Find<ModBuff>("ConcentratedTinctureBuff").Type))
			{
				int newLife = 2;
				Main.player[Projectile.owner].statLife += newLife;
				Main.player[Projectile.owner].HealEffect(newLife);
			}
			else
			{
				int newLife = 1;
				Main.player[Projectile.owner].statLife += newLife;
				Main.player[Projectile.owner].HealEffect(newLife);
			}
		}
		public override void AI()
		{
			Projectile.frameCounter++;
			if (Projectile.frameCounter > 2)
			{
				Projectile.frame++;
				Projectile.frameCounter = 0;
			}
			if (Projectile.frame >= 7)
			{ Projectile.velocity.X = 0f; Projectile.velocity.Y = 0f; }
			if (Projectile.frame >= 12)
			{ Projectile.Kill(); }
		}

	}
}