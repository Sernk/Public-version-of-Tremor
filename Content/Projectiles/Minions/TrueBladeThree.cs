using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using TremorMod.Utilities;

namespace TremorMod.Content.Projectiles.Minions
{
	public class TrueBladeThree : ModProjectile
	{

        const float RotationSpeed = 5f;
        const float Distanse = 150;
        const int HitCooldown = 12;  // 10 - 12 или 12 - 15

        float Rotation;
        int lastHitTime;

        public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void SetDefaults()
		{
			Projectile.width = 22;
			Projectile.height = 44;
			Projectile.timeLeft = 6;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.aiStyle = -1;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("True Blade");
		}

		public override void AI()
		{
			Rotation += RotationSpeed;
			Projectile.Center = Helper.PolarPos(Main.LocalPlayer.Center, Distanse, MathHelper.ToRadians(Rotation));
			Projectile.rotation = Helper.rotateBetween2Points(Main.LocalPlayer.Center, Projectile.Center) - MathHelper.ToRadians(90);
            if (lastHitTime > 0)
            {
                lastHitTime--;
            }
        }

        public override bool? CanHitNPC(NPC target)
        {

            if (lastHitTime <= 0 && !target.friendly)
            {
                lastHitTime = HitCooldown;
                return true;
            }
            return false;
        }
	}
}
