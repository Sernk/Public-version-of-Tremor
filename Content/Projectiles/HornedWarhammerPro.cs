using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class HornedWarhammerPro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(595);
            Projectile.aiStyle = 595;
            //AiType = 595;
			Projectile.width = 70;
			Projectile.light = 0.8f;
			Projectile.height = 70;
			Main.projFrames[Projectile.type] = 28;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("HornedWarhammerPro");
		}
	}
}
