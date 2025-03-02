using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class MythrilDiscPro : ModProjectile
	{
		public override void SetDefaults()
		{
            Projectile.CloneDefaults(ProjectileID.LightDisc);
            Projectile.aiStyle = 106;
        }

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("MythrilDiscPro");
		}
	}
}