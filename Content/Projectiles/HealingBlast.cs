using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Projectiles
{
	public class HealingBlast : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 5;
		}

		public override void SetDefaults()
		{
			Projectile.timeLeft = 420;
			Projectile.width = 52;
			Projectile.height = 52;
			Projectile.friendly = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void AI()
		{
			Projectile.frameCounter++;
			if (Projectile.frameCounter > 2)
			{
				Projectile.frame++;
				Projectile.frameCounter = 0;
			}
			if (Projectile.frame >= 5)
			{ Projectile.Kill(); }
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
	}
}