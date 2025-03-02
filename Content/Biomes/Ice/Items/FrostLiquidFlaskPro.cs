using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace TremorMod.Content.Biomes.Ice.Items
{
	public class FrostLiquidFlaskPro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 18;
			Projectile.height = 28;
			Projectile.friendly = true;
			Projectile.aiStyle = 2;
			Projectile.timeLeft = 1200;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Frost Liquid Flask Pro");
		}

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item107, Projectile.position);
            Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.position, -Projectile.oldVelocity * 0.2f, 704);
            Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.position, -Projectile.oldVelocity * 0.2f, 705);
            Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.position, -Projectile.oldVelocity * 0.2f, 705);
            Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.position, -Projectile.oldVelocity * 0.2f, 705);

            if (Projectile.owner == Main.myPlayer)
            {
                int num220 = Main.rand.Next(6, 20);
                for (int num221 = 0; num221 < num220; num221++)
                {
                    Vector2 value17 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                    value17.Normalize();
                    value17 *= Main.rand.Next(10, 201) * 0.01f;
                    Projectile.NewProjectile(
                        Projectile.GetSource_FromThis(),
                        Projectile.position,
                        value17,
                        118,
                        Projectile.damage,
                        1f,
                        Projectile.owner,
                        0f,
                        Main.rand.Next(-45, 1)
                    );
                }
            }
        }
    }
}