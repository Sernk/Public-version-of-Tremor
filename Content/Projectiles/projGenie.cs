using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class projGenie : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 38;
			Projectile.height = 60;
			Projectile.aiStyle = 26;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 10;
			Projectile.ignoreWater = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Genie");

		}

		public override void AI()
		{
			Lighting.AddLight(Projectile.Center, new Vector3(0, 0, 1.5f));
			Projectile.alpha = 0;
		}

		public override bool PreDraw(ref Color lightColor)
		{
            SpriteBatch spriteBatch = Main.spriteBatch;
            spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, new Rectangle((int)(Projectile.position.X - Main.screenPosition.X), (int)(Projectile.position.Y - Main.screenPosition.Y), 38, 60), null, Color.White, 0, new Vector2(2, 2), ((Main.player[Projectile.owner].position.X < Projectile.position.X) ? SpriteEffects.FlipHorizontally : SpriteEffects.None), 0);
			return false;
		}
	}
}
