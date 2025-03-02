using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class GoldenWhalePro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.ZephyrFish);

			AIType = ProjectileID.ZephyrFish;
			Main.projFrames[Projectile.type] = 4;
			Projectile.width = 72;
			//projectile.noGravity = true;
			Projectile.height = 38;
			Main.projPet[Projectile.type] = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Golden Whale");

		}

		public override bool PreAI()
		{
			Player player = Main.player[Projectile.owner];
			player.bunny = false; // Relic from aiType
			return true;
		}

        public override void AI()
        {
            Lighting.AddLight(Projectile.Center, new Vector3(0, 0, 1.5f));
            Projectile.alpha = 0;
        }
    }
}
