using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class ZootalooPet : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.ZephyrFish);

			AIType = ProjectileID.ZephyrFish;
			Main.projFrames[Projectile.type] = 4;
			Projectile.width = 46;
			Projectile.height = 56;
			Main.projPet[Projectile.type] = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Zootaloo Pet");

		}

		public override bool PreAI()
		{
			Player player = Main.player[Projectile.owner];
			player.bunny = false; // Relic from aiType
			return true;
		}
	}
}
