using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class ClusterBlast : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 10;
		}

		public override void SetDefaults()
		{
			Projectile.timeLeft = 420;
			Projectile.width = 60;
			Projectile.height = 60;
			Projectile.friendly = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void OnKill(int timeLeft)
		{
			if (Projectile.scale > 0.85f)
			{
				Vector2 valuekok = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
				valuekok.Normalize();
				valuekok *= Main.rand.Next(10, 201) * 0.01f;
				int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, valuekok.X, valuekok.Y, Mod.Find<ModProjectile>("ClusterBlastPro").Type, Projectile.damage, 0.8f, Projectile.owner, 2f, Main.rand.Next(-45, 45));
				Main.projectile[proj].scale = 0.8f;
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
			if (Projectile.frame >= 10)
			{ Projectile.Kill(); }
		}
	}
}