using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class Brutty : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(269);

			AIType = 269;
			Main.projFrames[Projectile.type] = 7;
			Projectile.width = 32;
			Projectile.height = 28;
			Main.projPet[Projectile.type] = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Brutty");

		}

		public override bool PreAI()
		{
			Player player = Main.player[Projectile.owner];
			player.bunny = false; // Relic from aiType
			return true;
		}
	}
}
