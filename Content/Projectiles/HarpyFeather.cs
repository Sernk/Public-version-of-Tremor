using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class HarpyFeather : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 6;
			Projectile.aiStyle = 1;
			Projectile.timeLeft = 600;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Harpy");

		}

		public override void OnKill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Grass, Projectile.position);
		}

	}
}
