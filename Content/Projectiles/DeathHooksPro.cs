using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Dusts;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Projectiles
{
	public class DeathHooksPro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(481);

			Projectile.width = 18;
			Projectile.height = 32;
			AIType = 481;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("DeathHooksPro");

		}

		public override bool PreDraw(ref Color lightColor)
		{
            Texture2D texture = ModContent.Request<Texture2D>("TremorMod/Content/Projectiles/DeathHooks_Chain").Value;

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
			if (Main.rand.NextBool(2))
			{
				target.AddBuff(Mod.Find<ModBuff>("DeathFear").Type, 480, false);
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

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP && Main.rand.NextBool(2))
            {
                target.AddBuff(ModContent.BuffType<DeathFear>(), 480, false);
            }
        }
    }
}