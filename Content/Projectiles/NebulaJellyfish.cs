using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class NebulaJellyfish : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.ZephyrFish);

			AIType = ProjectileID.ZephyrFish;
			Main.projFrames[Projectile.type] = 4;
			Projectile.width = 34;
			Projectile.height = 34;
			Main.projPet[Projectile.type] = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Nebula Jellyfish");

		}

		public override bool PreAI()
		{
			Player player = Main.player[Projectile.owner];
			player.bunny = false; // Relic from aiType
			return true;
		}
	}
}
