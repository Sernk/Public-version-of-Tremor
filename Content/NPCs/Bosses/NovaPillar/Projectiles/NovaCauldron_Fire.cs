using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using ReLogic.Utilities;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Filters = Terraria.Graphics.Effects.Filters;

namespace TremorMod.Content.NPCs.Bosses.NovaPillar.Projectiles
{
	public class NovaCauldron_Fire : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 12;
			Projectile.height = 12;
			Projectile.hostile = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
			Projectile.extraUpdates = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
		}

		public override bool PreAI()
		{
			for (int i = 0; i < 10; i++)
			{
				float x = Projectile.Center.X - Projectile.velocity.X / 10f * i;
				float y = Projectile.Center.Y - Projectile.velocity.Y / 10f * i;
				int dust = Dust.NewDust(new Vector2(x, y), 1, 1, 57, 0f, 0f, 0, default(Color), 1f);
				Main.dust[dust].alpha = Projectile.alpha;
				Main.dust[dust].position.X = x;
				Main.dust[dust].position.Y = y;
				Main.dust[dust].velocity *= 0f;
				Main.dust[dust].noGravity = true;
			}
			if (Projectile.localAI[1] == 0f)
			{
				Projectile.localAI[1] = 1f;
			}
			if (Projectile.ai[0] == 0f || Projectile.ai[0] == 2f)
			{
				Projectile.scale += 0.01f;
				Projectile.alpha -= 50;
				if (Projectile.alpha <= 0)
				{
					Projectile.ai[0] = 1f;
					Projectile.alpha = 0;
				}
			}
			else if (Projectile.ai[0] == 1f)
			{
				Projectile.scale -= 0.01f;
				Projectile.alpha += 50;
				if (Projectile.alpha >= 255)
				{
					Projectile.ai[0] = 2f;
					Projectile.alpha = 255;
				}
			}
			return false;
		}

		public override void AI()
		{
			Projectile.localAI[0] += 1f;
			float num472 = Projectile.Center.X;
			float num473 = Projectile.Center.Y;
			float num474 = 400f;
			bool flag17 = false;
			for (int num475 = 0; num475 < 200; num475++)
			{
				if (Main.npc[num475].CanBeChasedBy(Projectile, false) && Collision.CanHit(Projectile.Center, 1, 1, Main.npc[num475].Center, 1, 1))
				{
					float num476 = Main.npc[num475].position.X + Main.npc[num475].width / 2;
					float num477 = Main.npc[num475].position.Y + Main.npc[num475].height / 2;
					float num478 = Math.Abs(Projectile.position.X + Projectile.width / 2 - num476) + Math.Abs(Projectile.position.Y + Projectile.height / 2 - num477);
					if (num478 < num474)
					{
						num474 = num478;
						num472 = num476;
						num473 = num477;
						flag17 = true;
					}
				}
			}
			if (flag17)
			{
				float num483 = 10f;
				Vector2 vector35 = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
				float num484 = num472 - vector35.X;
				float num485 = num473 - vector35.Y;
				float num486 = (float)Math.Sqrt(num484 * num484 + num485 * num485);
				num486 = num483 / num486;
				num484 *= num486;
				num485 *= num486;
				Projectile.velocity.X = (Projectile.velocity.X * 20f + num484) / 21f;
				Projectile.velocity.Y = (Projectile.velocity.Y * 20f + num485) / 21f;
			}
		}

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);

            // Реализация взрыва вручную
            for (int i = 0; i < 40; i++)
            {
                int num = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 57, 0f, -2f, 0, default(Color), 2f);
                Main.dust[num].noGravity = true;
                Dust expr_62_cp_0 = Main.dust[num];
                expr_62_cp_0.position.X = expr_62_cp_0.position.X + (Main.rand.Next(-50, 51) / 20 - 1.5f);
                Dust expr_92_cp_0 = Main.dust[num];
                expr_92_cp_0.position.Y = expr_92_cp_0.position.Y + (Main.rand.Next(-50, 51) / 20 - 1.5f);
                if (Main.dust[num].position != Projectile.Center)
                {
                    Main.dust[num].velocity = Projectile.DirectionTo(Main.dust[num].position) * 6f;
                }
            }
        }


        public override bool PreDraw(ref Color lightColor)
        {
            // Получаем текстуру для данного типа проекта
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;

            // Рисуем спрайт вокруг центра
            Vector2 origin = Projectile.Center - Main.screenPosition;
            Main.spriteBatch.Draw(texture, origin, null, lightColor, Projectile.rotation, texture.Bounds.Size() / 2, Projectile.scale, SpriteEffects.None, 0f);

            return false;
        }


    }
}
