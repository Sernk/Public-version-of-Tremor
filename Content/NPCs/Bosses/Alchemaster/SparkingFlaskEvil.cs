using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace TremorMod.Content.NPCs.Bosses.Alchemaster
{
	public class SparkingFlaskEvil : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 18;
			Projectile.height = 28;
			Projectile.hostile = true;
			Projectile.aiStyle = 2;
			Projectile.timeLeft = 1200;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("SparkingFlaskEvil");

		}

		public override void OnKill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item107, Projectile.position);
            IEntitySource source = Projectile.GetSource_FromThis();
            Gore.NewGore(source, Projectile.position, -Projectile.oldVelocity * 0.2f, 704, 1f);
            Gore.NewGore(source, Projectile.position, -Projectile.oldVelocity * 0.2f, 705, 1f);
            //if (projectile.owner == Main.myPlayer)
            //{
            int num220 = Main.rand.Next(3, 5);
			for (int num221 = 0; num221 < num220; num221++)
			{
				Vector2 value17 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
				value17.Normalize();
				value17 *= Main.rand.Next(10, 201) * 0.01f;
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, value17.X, value17.Y, ModContent.ProjectileType<SparkingFlaskEvilTwo>(), Projectile.damage, 1f, Projectile.owner, 0f, Main.rand.Next(-45, 1));
			}
			//}
		}

	}
}
