using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class IchorCleaverPro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(595);
			Projectile.width = 100;
			Projectile.height = 70;
			AIType = 595;
			Main.projFrames[Projectile.type] = 28;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (Main.rand.NextBool(6))
			{
				target.AddBuff(69, 500, false);
			}
		}
	}
}