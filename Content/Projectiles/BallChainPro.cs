using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using TremorMod.Utilities;

namespace TremorMod.Content.Projectiles
{
	public class BallChainPro : ModProjectile
	{
        const float RotationSpeed = 3.00f;
        const float Distanse = 320;
        const int HitCooldown = 20; // Количество тиков между ударами (1 тик = 1/60 секунды)

        float Rotation;
        int lastHitTime;

        public override void SetDefaults()
		{

			Projectile.width = 48;
			Projectile.height = 48;
			Projectile.timeLeft = 6;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.aiStyle = -1;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ball n Chain");
		}

        public override void AI()
        {
            Rotation += RotationSpeed;
            Projectile.Center = Helper.PolarPos(Main.LocalPlayer.Center, Distanse, MathHelper.ToRadians(Rotation));
            Projectile.rotation = Helper.RotateBetween2Points(Main.LocalPlayer.Center, Projectile.Center) - MathHelper.ToRadians(90);

            // Обновление таймера
            if (lastHitTime > 0)
            {
                lastHitTime--;
            }
        }

        public override bool? CanHitNPC(NPC target)
        {
            // Проверка таймера перед нанесением удара
            if (lastHitTime <= 0 && !target.friendly)
            {
                lastHitTime = HitCooldown; // Сброс таймера
                return true;
            }
            return false;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>("TremorMod/Content/Projectiles/BallChain_Chain").Value;

            Vector2 position = Projectile.Center;
            Vector2 mountedCenter = Main.player[Projectile.owner].MountedCenter;
            Rectangle? sourceRectangle = new Rectangle?();
            Vector2 origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
            float num1 = texture.Height;
            Vector2 vector2_4 = mountedCenter - position;
            float rotation = (float)Math.Atan2(vector2_4.Y, vector2_4.X) - 1.57f;
            bool flag = !(float.IsNaN(position.X) && float.IsNaN(position.Y));
            if (float.IsNaN(vector2_4.X) && float.IsNaN(vector2_4.Y))
                flag = false;
            while (flag)
            {
                if (vector2_4.Length() < num1 + 1.0)
                {
                    flag = false;
                }
                else
                {
                    Vector2 vector2_1 = vector2_4;
                    vector2_1.Normalize();
                    position += vector2_1 * num1;
                    vector2_4 = mountedCenter - position;
                    Color color2 = Lighting.GetColor((int)position.X / 16, (int)(position.Y / 16.0));
                    color2 = Projectile.GetAlpha(color2);
                    Main.spriteBatch.Draw(texture, position - Main.screenPosition, sourceRectangle, color2, rotation, origin, 1f, SpriteEffects.None, 0.0f);
                }
            }
            return true;
        }
    }
}