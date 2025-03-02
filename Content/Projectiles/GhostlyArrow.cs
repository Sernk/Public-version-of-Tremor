using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace TremorMod.Content.Projectiles
{
	//ported from my tAPI mod because I don't want to make artwork
	public class GhostlyArrow : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 16;
			Projectile.height = 40;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = -2;
			Projectile.tileCollide = true;
			Projectile.DamageType = DamageClass.Melee;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ghostly Arrow");

		}

		public override void OnKill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item93, Projectile.position);

			IEntitySource source = Projectile.GetSource_Death(); 
			Vector2 position = Projectile.Center;
			Vector2 velocity = Vector2.Zero;

			Projectile.NewProjectile(source, position, velocity,
				ModContent.ProjectileType<GhostlyExplosion>(),
				Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0f);
		}
	}
}