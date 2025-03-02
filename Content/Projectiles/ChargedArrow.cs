using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace TremorMod.Content.Projectiles
{
	//ported from my tAPI mod because I don't want to make artwork
	public class ChargedArrow : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 16;
			Projectile.height = 40;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = -2;
			Projectile.tileCollide = true;
			Projectile.DamageType = DamageClass.Melee;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Charged Arrow");

		}

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item93, Projectile.position);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<ChargedArrowBoom>(), Projectile.damage, (int)Projectile.knockBack, Projectile.owner, 0f, 0f);
        }

    }
}