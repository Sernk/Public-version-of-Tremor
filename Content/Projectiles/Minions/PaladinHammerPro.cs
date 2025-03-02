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
	public class PaladinHammerPro : ModProjectile
	{
		const float RotationSpeed = 5f;
		const float Distanse = 48;
        const int HitCooldown = 12;  // 10 - 12 или 12 - 15

        float Rotation;
        int lastHitTime;

        public override void SetDefaults()
		{
			Projectile.width = 18;
			Projectile.height = 34;
			Projectile.timeLeft = 6;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.aiStyle = -1;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("PaladinHammerPro");
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
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

		public override bool PreDraw(ref Color lightColor)
		{
            SpriteBatch spriteBatch = Main.spriteBatch;
            Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
			for (int k = 0; k < Projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
				Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
				spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}
	}
}
