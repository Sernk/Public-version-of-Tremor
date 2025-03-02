using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Dusts;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Projectiles
{
	public class HorrificKnifePro : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 14;
			Projectile.height = 32;
			Projectile.friendly = true;
			Projectile.aiStyle = 1;
			Projectile.timeLeft = 1200;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Horrific Dagger");
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (Main.rand.NextBool())
			{
				target.AddBuff(ModContent.BuffType<DeathFear>(), 480, false);
			}
		}

		public override void OnKill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<NightmareFlame>(), Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 2f, 100, default(Color), 2f);
			}
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
		}
	}
}
