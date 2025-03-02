using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class AdamantiteCloud : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 40;
			Projectile.height = 40;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 8;
			Projectile.aiStyle = 92;
			Projectile.friendly = true;
			Projectile.timeLeft = 600;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("PurpleCloudPro");

		}*/

	}
}
