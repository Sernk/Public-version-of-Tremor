using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace TremorMod.Content.Biomes.Ice.Items
{
	public class Icoj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ice Proj");
		}
		float rotationProj;
		public override void SetDefaults()
		{
			Projectile.width = 92;
			Projectile.height = 102;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 3600;
			Projectile.tileCollide = false;
			Projectile.extraUpdates = 1;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		int timer;
		public override void AI()
		{
			timer++;
			rotationProj += 0.097f;
			Projectile.rotation = rotationProj;
			Projectile.velocity.X = 0f;
			Projectile.velocity.Y = 0f;

			if (timer >= 350)
			{
				Projectile.alpha++;
				Projectile.alpha++;
			}

            if (Projectile.alpha >= 255)
            {
                var source = Projectile.GetSource_FromThis(); 

                Projectile.NewProjectile(source, Projectile.position + new Vector2(40, 40), new Vector2(-7, 0), 119, Projectile.damage, 0, Main.myPlayer);
                Projectile.NewProjectile(source, Projectile.position + new Vector2(40, 40), new Vector2(7, 0), 119, Projectile.damage, 0, Main.myPlayer);
                Projectile.NewProjectile(source, Projectile.position + new Vector2(40, 40), new Vector2(0, 7), 119, Projectile.damage, 0, Main.myPlayer);
                Projectile.NewProjectile(source, Projectile.position + new Vector2(40, 40), new Vector2(0, -7), 119, Projectile.damage, 0, Main.myPlayer);
                Projectile.NewProjectile(source, Projectile.position + new Vector2(40, 40), new Vector2(-7, -7), 119, Projectile.damage, 0, Main.myPlayer);
                Projectile.NewProjectile(source, Projectile.position + new Vector2(40, 40), new Vector2(7, -7), 119, Projectile.damage, 0, Main.myPlayer);
                Projectile.NewProjectile(source, Projectile.position + new Vector2(40, 40), new Vector2(-7, 7), 119, Projectile.damage, 0, Main.myPlayer);
                Projectile.NewProjectile(source, Projectile.position + new Vector2(40, 40), new Vector2(7, 7), 119, Projectile.damage, 0, Main.myPlayer);

                Projectile.Kill();
            }
        }
	}
}