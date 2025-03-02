using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class DragonHeadPro : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 36;
			Projectile.height = 24;
			Projectile.friendly = true;
			Projectile.penetrate = -1; // Penetrates NPCs infinitely.
			Projectile.DamageType = DamageClass.Melee; // Deals melee dmg.

			Projectile.aiStyle = 15; // Set the aiStyle to that of a flail.
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ancient Flail");

		}

		public override bool PreDraw(ref Color lightColor)
		{
            Texture2D texture = ModContent.Request<Texture2D>("TremorMod/Content/Projectiles/DragonHeadPro_Chain").Value;

            Vector2 position = Projectile.Center;
			Vector2 mountedCenter = Main.player[Projectile.owner].MountedCenter;
			Rectangle? sourceRectangle = new Rectangle?();
			Vector2 origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
			float num1 = texture.Height;
			Vector2 vector2_4 = mountedCenter - position;
			float rotation = (float)Math.Atan2(vector2_4.Y, vector2_4.X) - 1.57f;
			bool flag = true;
			if (float.IsNaN(position.X) && float.IsNaN(position.Y))
				flag = false;
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

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextBool(3))
            {
                var source = Projectile.GetSource_FromThis();
                Vector2 position = Projectile.Center;
                Vector2 velocity = Vector2.Zero;
                Projectile.NewProjectile(
                    source,             
                    position,           
                    velocity,          
                    400,                
                    Projectile.damage,  
                    Projectile.knockBack,
                    Projectile.owner    
                );
            }
        }

    }
}
