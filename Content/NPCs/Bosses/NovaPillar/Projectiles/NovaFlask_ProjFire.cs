using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.NPCs.Bosses.NovaPillar.Projectiles
{
	public class NovaFlask_ProjFire : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 12;
			Projectile.height = 24;
			Main.projFrames[Projectile.type] = 3;
			Projectile.timeLeft = 600;
			Projectile.maxPenetrate = -1;
			Projectile.hostile = false;
			Projectile.friendly = true;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override bool PreAI()
		{
			Projectile.frameCounter++;
			if (Projectile.frameCounter > 3)
			{
				Projectile.frame++;
				Projectile.frameCounter = 0;
			}
			if (Projectile.frame >= 3)
			{
				Projectile.frame = 0;
			}
			float num2 = (float)Math.Sqrt(Projectile.velocity.X * Projectile.velocity.X + Projectile.velocity.Y * Projectile.velocity.Y);
			float num3 = Projectile.localAI[0];
			if (num3 == 0f)
			{
				Projectile.localAI[0] = num2;
				num3 = num2;
			}
			float num4 = Projectile.position.X;
			float num5 = Projectile.position.Y;
			float num6 = 300f;
			bool flag = false;
			int num7 = 0;
			if (Projectile.ai[1] == 0f)
			{
				for (int j = 0; j < 200; j++)
				{
					if (Main.npc[j].CanBeChasedBy(this, false) && (Projectile.ai[1] == 0f || Projectile.ai[1] == j + 1))
					{
						float num8 = Main.npc[j].position.X + Main.npc[j].width / 2;
						float num9 = Main.npc[j].position.Y + Main.npc[j].height / 2;
						float num10 = Math.Abs(Projectile.position.X + Projectile.width / 2 - num8) + Math.Abs(Projectile.position.Y + Projectile.height / 2 - num9);
						if (num10 < num6 && Collision.CanHit(new Vector2(Projectile.position.X + Projectile.width / 2, Projectile.position.Y + Projectile.height / 2), 1, 1, Main.npc[j].position, Main.npc[j].width, Main.npc[j].height))
						{
							num6 = num10;
							num4 = num8;
							num5 = num9;
							flag = true;
							num7 = j;
						}
					}
				}
				if (flag)
				{
					Projectile.ai[1] = num7 + 1;
				}
				flag = false;
			}
			if (Projectile.ai[1] > 0f)
			{
				int num11 = (int)(Projectile.ai[1] - 1f);
				if (Main.npc[num11].active && Main.npc[num11].CanBeChasedBy(this, true) && !Main.npc[num11].dontTakeDamage)
				{
					float num12 = Main.npc[num11].position.X + Main.npc[num11].width / 2;
					float num13 = Main.npc[num11].position.Y + Main.npc[num11].height / 2;
					float num14 = Math.Abs(Projectile.position.X + Projectile.width / 2 - num12) + Math.Abs(Projectile.position.Y + Projectile.height / 2 - num13);
					if (num14 < 1000f)
					{
						flag = true;
						num4 = Main.npc[num11].position.X + Main.npc[num11].width / 2;
						num5 = Main.npc[num11].position.Y + Main.npc[num11].height / 2;
					}
				}
				else
				{
					Projectile.ai[1] = 0f;
				}
			}
			if (!Projectile.friendly)
			{
				flag = false;
			}
			if (flag)
			{
				float num15 = num3;
				Vector2 vector = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
				float num16 = num4 - vector.X;
				float num17 = num5 - vector.Y;
				float num18 = (float)Math.Sqrt(num16 * num16 + num17 * num17);
				num18 = num15 / num18;
				num16 *= num18;
				num17 *= num18;
				int num19 = 8;
				Projectile.velocity.X = (Projectile.velocity.X * (num19 - 1) + num16) / num19;
				Projectile.velocity.Y = (Projectile.velocity.Y * (num19 - 1) + num17) / num19;
			}
			return false;
		}

        public static class Helper
        {
            public static void Explode(int whoAmI, int radiusX, int radiusY, Action explosionCallback)
            {
                // Логика для взрыва, например, проверка на области действия, урон и т.д.

                // Вызов коллбека после выполнения взрыва
                explosionCallback?.Invoke();
            }
        }


        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);

            // Вызов метода взрыва с соответствующими параметрами
            Helper.Explode(Projectile.whoAmI, 120, 120, delegate
            {
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
            });
        }

    }
}
