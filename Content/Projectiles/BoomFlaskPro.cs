using System;
using Terraria.Audio;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using TremorMod;
using TremorMod.Content;
using TremorMod.Content.Buffs;
using TremorMod.Content.Projectiles;
using TremorMod.Utilities;

namespace TremorMod.Content.Projectiles
{
	public class BoomFlaskPro : ModProjectile
	{
        public static class Helper
        {
            private static readonly Random random = new Random();

            public static Vector2 RandomPointInArea(Vector2 topLeft, Vector2 bottomRight)
            {
                float x = (float)(random.NextDouble() * (bottomRight.X - topLeft.X) + topLeft.X);
                float y = (float)(random.NextDouble() * (bottomRight.Y - topLeft.Y) + topLeft.Y);
                return new Vector2(x, y);
            }

            public static Vector2 VelocityToPoint(Vector2 origin, Vector2 target, float speed)
            {
                Vector2 direction = target - origin;
                direction.Normalize();
                return direction * speed;
            }
        }

		/*public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 2;
		}*/

        public override void SetDefaults()
		{
			Projectile.width = 18;
			Projectile.height = 28;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.penetrate = 1;
			Projectile.aiStyle = 2;
			Projectile.timeLeft = 1200;
		}

        public override void OnSpawn(IEntitySource source)
        {
            Player player = Main.player[Projectile.owner];

            if (player.HasBuff(ModContent.BuffType<BouncingCasingBuff>()))
            {
                Projectile.penetrate = 3;
            }
        }

        public override void AI()
        {
            if (Main.LocalPlayer.HasBuff(ModContent.BuffType<TheCadenceBuff>()))
            {
                int[] array = new int[20];
                int num428 = 0;
                float num429 = 495f;
                bool flag14 = false;
                for (int num430 = 0; num430 < 200; num430++)
                {
                    if (Main.npc[num430].CanBeChasedBy(Projectile, false))
                    {
                        float num431 = Main.npc[num430].position.X + Main.npc[num430].width / 2;
                        float num432 = Main.npc[num430].position.Y + Main.npc[num430].height / 2;
                        float num433 = Math.Abs(Projectile.position.X + Projectile.width / 2 - num431) + Math.Abs(Projectile.position.Y + Projectile.height / 2 - num432);
                        if (num433 < num429 && Collision.CanHit(Projectile.Center, 1, 1, Main.npc[num430].Center, 1, 1))
                        {
                            if (num428 < 20)
                            {
                                array[num428] = num430;
                                num428++;
                            }
                            flag14 = true;
                        }
                    }
                }
                if (flag14)
                {
                    int num434 = Main.rand.Next(num428);
                    num434 = array[num434];
                    float num435 = Main.npc[num434].position.X + Main.npc[num434].width / 2;
                    float num436 = Main.npc[num434].position.Y + Main.npc[num434].height / 2;
                    Projectile.localAI[0] += 1f;
                    if (Projectile.localAI[0] > 8f)
                    {
                        Projectile.localAI[0] = 0f;
                        float num437 = 6f;
                        Vector2 value10 = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
                        value10 += Projectile.velocity * 4f;
                        float num438 = num435 - value10.X;
                        float num439 = num436 - value10.Y;
                        float num440 = (float)Math.Sqrt(num438 * num438 + num439 * num439);
                        num440 = num437 / num440;
                        num438 *= num440;
                        num439 *= num440;
                        if (Main.rand.NextBool(2))
                        {
                            Projectile.NewProjectile(
                                Projectile.GetSource_FromThis(), // Используем правильный источник
                                value10.X, value10.Y,
                                num438, num439,
                                ModContent.ProjectileType<TheCadenceProj>(),
                                Projectile.damage,
                                Projectile.knockBack,
                                Projectile.owner,
                                0f, 0f);
                        }
                    }
                }
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (Main.LocalPlayer.HasBuff(ModContent.BuffType<BouncingCasingBuff>()))
			{
				Projectile.penetrate--;
				if (Projectile.penetrate <= 0)
				{
					Projectile.Kill();
				}
				else
				{
					if (Projectile.velocity.X != oldVelocity.X)
					{
						Projectile.velocity.X = -oldVelocity.X;
					}
					if (Projectile.velocity.Y != oldVelocity.Y)
					{
						Projectile.velocity.Y = -oldVelocity.Y;
					}
                    SoundEngine.PlaySound(SoundID.Item20, Projectile.position);
                }
			}
			else
			{
				Projectile.Kill();
			}

			return false;
		}

		public override void OnKill(int timeLeft)
		{
            Player player = Main.player[Projectile.owner];
            var modPlayer = player.GetModPlayer<MPlayer>();
            IEntitySource source = Projectile.GetSource_FromThis(); // Источник для создания нового Projectile

            if (player.HasBuff(ModContent.BuffType<DesertEmperorSetBuff>()))
            {             
                int a = Projectile.NewProjectile(source, Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FlaskWasp>(), Projectile.damage * 2, 1.5f, Projectile.owner);
                int b = Projectile.NewProjectile(source, Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FlaskWasp>(), Projectile.damage * 2, 1.5f, Projectile.owner);
            }


            //MPlayer modPlayer = (MPlayer)player.GetModPlayer(mod, "MPlayer");

            if (player.HasBuff(ModContent.BuffType<BrassChipBuff>()))
            {
                for (int i = 0; i < 5; i++)
                {
                    // Угол изменяется на основе индекса
                    float angle = MathHelper.ToRadians(72 * i); // Делает равные интервалы (360° / 5 = 72°)

                    // Вычисление позиции снаряда
                    Vector2 vector2 = new Vector2(
                        player.position.X + 75f * (float)Math.Cos(angle),
                        player.position.Y + 75f * (float)Math.Sin(angle)
                    );

                    // Создание случайной точки в указанной области
                    Vector2 randomTarget = Helper.RandomPointInArea(
                        new Vector2(Projectile.Center.X - 10, Projectile.Center.Y - 10),
                        new Vector2(Projectile.Center.X + 20, Projectile.Center.Y + 20)
                    );

                    // Расчёт скорости
                    Vector2 velocity = Helper.VelocityToPoint(vector2, randomTarget, 24);

                    // Создание нового снаряда с правильным источником
                    int a = Projectile.NewProjectile(
                        source,
                        vector2.X, vector2.Y,
                        velocity.X, velocity.Y,
                        134,
                        Projectile.damage,
                        1f,
                        player.whoAmI
                    );

                    // Делаем снаряд дружественным
                    Main.projectile[a].friendly = true;
                }
            }

            if (player.HasBuff(ModContent.BuffType<ChaosElementBuff>()))
            {
                int num220 = Main.rand.Next(3, 6);
                for (int num221 = 0; num221 < num220; num221++)
                {
                    Vector2 value17 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                    value17.Normalize();
                    value17 *= Main.rand.Next(10, 201) * 0.01f;

                    // Создаем источник

                    // Создаем снаряд с использованием источника
                    Projectile.NewProjectile(
                        source,
                        Projectile.position.X,
                        Projectile.position.Y,
                        value17.X,
                        value17.Y,
                        ModContent.ProjectileType<Shatter1>(),
                        Projectile.damage,
                        1f,
                        Projectile.owner,
                        0f,
                        Main.rand.Next(-45, 1)
                    );
                }
            }

            SoundEngine.PlaySound(SoundID.Item20, Projectile.position);
            Projectile.position.X = Projectile.position.X + Projectile.width / 2;
			Projectile.position.Y = Projectile.position.Y + Projectile.height / 2;
			Projectile.width = 80;
			Projectile.height = 80;
			Projectile.position.X = Projectile.position.X - Projectile.width / 2;
			Projectile.position.Y = Projectile.position.Y - Projectile.height / 2;
			for (int num628 = 0; num628 < 40; num628++)
			{
				int num629 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
				Main.dust[num629].velocity *= 3f;
				if (Main.rand.NextBool(2))
				{
					Main.dust[num629].scale = 0.5f;
					Main.dust[num629].fadeIn = 1f + Main.rand.Next(10) * 0.1f;
				}
			}
			for (int num630 = 0; num630 < 70; num630++)
			{
				int num631 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 3f);
				Main.dust[num631].noGravity = true;
				Main.dust[num631].velocity *= 5f;
				num631 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
				Main.dust[num631].velocity *= 2f;
			}
            for (int num632 = 0; num632 < 3; num632++)
            {
                float scaleFactor10 = 0.33f;
                if (num632 == 1)
                {
                    scaleFactor10 = 0.66f;
                }
                if (num632 == 2)
                {
                    scaleFactor10 = 1f;
                }


                int num633 = Gore.NewGore(
                    source,
                    new Vector2(Projectile.position.X + Projectile.width / 2 - 24f, Projectile.position.Y + Projectile.height / 2 - 24f),
                    default(Vector2),
                    Main.rand.Next(61, 64),
                    1f
                );
                Main.gore[num633].velocity *= scaleFactor10;
                Main.gore[num633].velocity.X += 1f;
                Main.gore[num633].velocity.Y += 1f;

                num633 = Gore.NewGore(
                    source,
                    new Vector2(Projectile.position.X + Projectile.width / 2 - 24f, Projectile.position.Y + Projectile.height / 2 - 24f),
                    default(Vector2),
                    Main.rand.Next(61, 64),
                    2f
                );
                Main.gore[num633].velocity *= scaleFactor10;
                Main.gore[num633].velocity.X -= 1f;
                Main.gore[num633].velocity.Y += 1f;

                num633 = Gore.NewGore(
                    source,
                    new Vector2(Projectile.position.X + Projectile.width / 2 - 24f, Projectile.position.Y + Projectile.height / 2 - 24f),
                    default(Vector2),
                    Main.rand.Next(61, 64),
                    1f
                );
                Main.gore[num633].velocity *= scaleFactor10;
                Main.gore[num633].velocity.X += 1f;
                Main.gore[num633].velocity.Y -= 1f;

                num633 = Gore.NewGore(
                    source,
                    new Vector2(Projectile.position.X + Projectile.width / 2 - 24f, Projectile.position.Y + Projectile.height / 2 - 24f),
                    default(Vector2),
                    Main.rand.Next(61, 64),
                    1f
                );
                Main.gore[num633].velocity *= scaleFactor10;
                Main.gore[num633].velocity.X -= 1f;
                Main.gore[num633].velocity.Y -= 1f;
            }

            Projectile.position.X = Projectile.position.X + Projectile.width / 2;
			Projectile.position.Y = Projectile.position.Y + Projectile.height / 2;
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.position.X = Projectile.position.X - Projectile.width / 2;
			Projectile.position.Y = Projectile.position.Y - Projectile.height / 2;

            if (!modPlayer.pyro && !modPlayer.nitro)
            {
                if (Projectile.owner == Main.myPlayer)
                {
                    int num220 = Main.rand.Next(3, 8);
                    for (int num221 = 0; num221 < num220; num221++)
                    {
                        Vector2 value17 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                        value17.Normalize();
                        value17 *= Main.rand.Next(10, 201) * 0.01f;

                        // Создание нового снаряда
                        Projectile.NewProjectile(
                            source,
                            Projectile.position.X,
                            Projectile.position.Y,
                            value17.X,
                            value17.Y,
                            ModContent.ProjectileType<BoomCloudPro>(),
                            Projectile.damage,
                            1f,
                            Projectile.owner,
                            0f,
                            Main.rand.Next(-45, 1)
                        );
                    }
                }
            }

            if (Projectile.owner == Main.myPlayer)
            {
                if (player.HasBuff(ModContent.BuffType<PyroBuff>()) && !modPlayer.nitro)
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    Vector2 velocity = new Vector2(0, 0); // Создаем Vector2 для направления
                    int a = Projectile.NewProjectile(source, Projectile.position, velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1.5f, Projectile.owner);
                    Main.projectile[a].scale = 1.5f;
                }
                if (player.HasBuff(ModContent.BuffType<ChemikazeBuff>()) && !modPlayer.nitro)
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    Vector2 velocity = Vector2.Zero;
                    int a = Projectile.NewProjectile(source, Projectile.position, velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1.25f, Projectile.owner);
                    Main.projectile[a].scale = 1.25f;
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 32, Projectile.position.Y), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 32, Projectile.position.Y), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y + 32), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y - 32), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("CrossBlastBuff").Type) && !modPlayer.nitro)
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    Vector2 velocity = Vector2.Zero;
                    int a = Projectile.NewProjectile(source, Projectile.position, velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1.25f, Projectile.owner);
                    Main.projectile[a].scale = 1.25f;
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y + 30), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y - 30), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 50, Projectile.position.Y), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 0.7f, Projectile.owner);
                    Main.projectile[f].scale = 0.7f;
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 50, Projectile.position.Y), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 0.7f, Projectile.owner);
                    Main.projectile[g].scale = 0.7f;
                    int h = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y + 50), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 0.7f, Projectile.owner);
                    Main.projectile[h].scale = 0.7f;
                    int i = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y - 50), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 0.7f, Projectile.owner);
                    Main.projectile[i].scale = 0.7f;
                    int j = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 70, Projectile.position.Y), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 0.5f, Projectile.owner);
                    Main.projectile[j].scale = 0.8f;
                    int k = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 70, Projectile.position.Y), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 0.5f, Projectile.owner);
                    Main.projectile[k].scale = 0.8f;
                    int l = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y + 70), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 0.5f, Projectile.owner);
                    Main.projectile[l].scale = 0.8f;
                    int m = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y - 70), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 0.5f, Projectile.owner);
                    Main.projectile[m].scale = 0.8f;
                }
                if (player.HasBuff(Mod.Find<ModBuff>("RoundBlastBuff").Type) && !modPlayer.nitro)
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    Vector2 velocity = Vector2.Zero;
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 60, Projectile.position.Y), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 60, Projectile.position.Y), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y + 60), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y - 60), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 40, Projectile.position.Y + 40), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 40, Projectile.position.Y + 40), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 40, Projectile.position.Y - 40), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int h = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 40, Projectile.position.Y - 40), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("SquareBlastBuff").Type) && !modPlayer.nitro)
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    Vector2 velocity = Vector2.Zero;
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 70, Projectile.position.Y), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 70, Projectile.position.Y), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y + 70), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y - 70), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 70, Projectile.position.Y + 70), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 70, Projectile.position.Y + 70), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 70, Projectile.position.Y - 70), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int h = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 70, Projectile.position.Y - 70), velocity, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("NitroBuff").Type) && !modPlayer.pyro)
                {
                    SoundEngine.PlaySound(SoundID.Item100, Projectile.position);
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("BoomBurst").Type, Projectile.damage, 1f, Projectile.owner);
                }

                if (player.HasBuff(Mod.Find<ModBuff>("ReinforcedBurstBuff").Type) && !modPlayer.pyro)
                {
                    SoundEngine.PlaySound(SoundID.Item100, Projectile.position);
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("BoomBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 50, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("BoomBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 50, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("BoomBurst").Type, Projectile.damage, 1f, Projectile.owner);
                }

                if (player.HasBuff(Mod.Find<ModBuff>("LinearBurstBuff").Type) && !modPlayer.pyro)
                {
                    SoundEngine.PlaySound(SoundID.Item100, Projectile.position);
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("BoomBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 50, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("BoomBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 50, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("BoomBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 100, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("BoomBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 100, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("BoomBurst").Type, Projectile.damage, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("NitroBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("PyroBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item42, Projectile.position);
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1.5f, Projectile.owner);
                    Main.projectile[a].scale = 1.5f;
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 20, Projectile.position.Y), new Vector2(5, 0), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 20, Projectile.position.Y), new Vector2(-5, 0), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("ReinforcedBurstBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("PyroBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item42, Projectile.position);
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1.5f, Projectile.owner);
                    Main.projectile[a].scale = 1.5f;
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 10, Projectile.position.Y - 10), new Vector2(6, 0), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 10, Projectile.position.Y - 10), new Vector2(-6, 0), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 40, Projectile.position.Y + 10), new Vector2(4, 0), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 40, Projectile.position.Y + 10), new Vector2(-4, 0), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("LinearBurstBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("PyroBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item42, Projectile.position);
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1.5f, Projectile.owner);
                    Main.projectile[a].scale = 1.5f;
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 10, Projectile.position.Y - 15), new Vector2(6, 0), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 10, Projectile.position.Y - 15), new Vector2(-6, 0), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 40, Projectile.position.Y), new Vector2(5, 0), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 40, Projectile.position.Y), new Vector2(-5, 0), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 70, Projectile.position.Y + 15), new Vector2(4, 0), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 70, Projectile.position.Y + 15), new Vector2(-4, 0), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage, 1f, Projectile.owner);
                }

                if (player.HasBuff(Mod.Find<ModBuff>("RoundBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("NitroBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    int z = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1.5f, Projectile.owner);
                    Main.projectile[z].scale = 1.25f;
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 25, Projectile.position.Y), new Vector2(4, 0), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 25, Projectile.position.Y), new Vector2(-4, 0), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y + 25), new Vector2(0, 4), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y - 25), new Vector2(0, -4), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 20, Projectile.position.Y + 20), new Vector2(4, 4), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[e].scale = 0.8f;
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 20, Projectile.position.Y + 20), new Vector2(-4, 4), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[f].scale = 0.8f;
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 20, Projectile.position.Y - 20), new Vector2(4, -4), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[g].scale = 0.8f;
                    int h = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 20, Projectile.position.Y - 20), new Vector2(-4, -4), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[h].scale = 0.8f;
                }
                if (player.HasBuff(Mod.Find<ModBuff>("RoundBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("ReinforcedBurstBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    int z = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1.5f, Projectile.owner);
                    Main.projectile[z].scale = 1.25f;
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 65, Projectile.position.Y), new Vector2(3, 0), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 65, Projectile.position.Y), new Vector2(-3, 0), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y + 35), new Vector2(0, 4), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y - 35), new Vector2(0, -4), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 50, Projectile.position.Y + 20), new Vector2(0, 4), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[e].scale = 1.2f;
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 50, Projectile.position.Y + 20), new Vector2(0, 4), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[f].scale = 1.2f;
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 50, Projectile.position.Y - 20), new Vector2(0, -4), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[g].scale = 1.2f;
                    int h = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 50, Projectile.position.Y - 20), new Vector2(0, -4), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[h].scale = 1.2f;
                }

                if (player.HasBuff(Mod.Find<ModBuff>("RoundBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("LinearBurstBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    int z = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1.5f, Projectile.owner);
                    Main.projectile[z].scale = 1.25f;
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 65, Projectile.position.Y), new Vector2(3, 0), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 65, Projectile.position.Y), new Vector2(-3, 0), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y + 35), new Vector2(0, 4), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y - 35), new Vector2(0, -4), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 50, Projectile.position.Y + 20), new Vector2(0, 4), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[e].scale = 0.8f;
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 50, Projectile.position.Y + 20), new Vector2(0, 4), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[f].scale = 0.8f;
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 50, Projectile.position.Y - 20), new Vector2(0, -4), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[g].scale = 0.8f;
                    int h = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 50, Projectile.position.Y - 20), new Vector2(0, -4), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[h].scale = 0.8f;
                    int i = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 80, Projectile.position.Y + 20), new Vector2(0, 4), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[i].scale = 0.6f;
                    int k = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 80, Projectile.position.Y + 20), new Vector2(0, 4), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[k].scale = 0.6f;
                    int l = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 80, Projectile.position.Y - 20), new Vector2(0, -4), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[l].scale = 0.6f;
                    int m = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 80, Projectile.position.Y - 20), new Vector2(0, -4), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[m].scale = 0.6f;
                }
                if (player.HasBuff(Mod.Find<ModBuff>("SquareBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("NitroBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[d].scale = 1.5f;
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y + 30), new Vector2(3, 3), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y + 30), new Vector2(-3, 3), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y - 30), new Vector2(3, -3), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int h = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y - 30), new Vector2(-3, -3), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("SquareBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("ReinforcedBurstBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[d].scale = 1.5f;
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y + 30), new Vector2(2, 3), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[e].scale = 0.75f;
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y + 30), new Vector2(-2, 3), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[f].scale = 0.75f;
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y - 30), new Vector2(2, -3), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[g].scale = 0.75f;
                    int h = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y - 30), new Vector2(-2, -3), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[h].scale = 0.75f;
                    int i = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y + 30), new Vector2(3, 2), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[i].scale = 0.75f;
                    int j = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y + 30), new Vector2(-3, 2), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[j].scale = 0.75f;
                    int k = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y - 30), new Vector2(3, -2), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[k].scale = 0.75f;
                    int l = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y - 30), new Vector2(-3, -2), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[l].scale = 0.75f;
                }
                if (player.HasBuff(Mod.Find<ModBuff>("SquareBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("LinearBurstBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("BoomBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[d].scale = 1.5f;
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y + 30), new Vector2(2, 4), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[e].scale = 0.65f;
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y + 30), new Vector2(-2, 4), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[f].scale = 0.65f;
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y - 30), new Vector2(2, -4), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[g].scale = 0.65f;
                    int h = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y - 30), new Vector2(-2, -4), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[h].scale = 0.65f;
                    int i = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y + 30), new Vector2(4, 2), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[i].scale = 0.65f;
                    int j = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y + 30), new Vector2(-4, 2), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[j].scale = 0.65f;
                    int k = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y - 30), new Vector2(4, -2), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[k].scale = 0.65f;
                    int l = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y - 30), new Vector2(-4, -2), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[l].scale = 0.65f;
                    int m = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y + 30), new Vector2(3, 3), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[m].scale = 0.7f;
                    int n = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y + 30), new Vector2(-3, 3), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[n].scale = 0.7f;
                    int o = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y - 30), new Vector2(3, -3), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[o].scale = 0.7f;
                    int p = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y - 30), new Vector2(-3, -3), Mod.Find<ModProjectile>("BoomSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[p].scale = 0.7f;
                }
                if (player.HasBuff(Mod.Find<ModBuff>("NitroBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("ChemikazeBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item100, Projectile.position);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y), new Vector2(-2, 0), Mod.Find<ModProjectile>("BoomBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y), new Vector2(2, 0), Mod.Find<ModProjectile>("BoomBurst").Type, Projectile.damage, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("ReinforcedBurstBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("ChemikazeBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item100, Projectile.position);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 40, Projectile.position.Y), new Vector2(-2, 0), Mod.Find<ModProjectile>("BoomBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 40, Projectile.position.Y), new Vector2(2, 0), Mod.Find<ModProjectile>("BoomBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 60, Projectile.position.Y), new Vector2(-3, 0), Mod.Find<ModProjectile>("BoomBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 60, Projectile.position.Y), new Vector2(3, 0), Mod.Find<ModProjectile>("BoomBurst").Type, Projectile.damage, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("LinearBurstBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("ChemikazeBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item100, Projectile.position);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 40, Projectile.position.Y), new Vector2(-2, 0), Mod.Find<ModProjectile>("BoomBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 40, Projectile.position.Y), new Vector2(2, 0), Mod.Find<ModProjectile>("BoomBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 60, Projectile.position.Y), new Vector2(-3, 0), Mod.Find<ModProjectile>("BoomBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 60, Projectile.position.Y), new Vector2(3, 0), Mod.Find<ModProjectile>("BoomBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 80, Projectile.position.Y), new Vector2(-4, 0), Mod.Find<ModProjectile>("BoomBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 80, Projectile.position.Y), new Vector2(4, 0), Mod.Find<ModProjectile>("BoomBurst").Type, Projectile.damage, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("CrossBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("NitroBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(4, 0), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(-4, 0), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(0, 4), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(0, -4), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 60, Projectile.position.Y), new Vector2(-4, 0), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 60, Projectile.position.Y), new Vector2(4, 0), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y + 60), new Vector2(0, -4), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int h = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y - 60), new Vector2(0, 4), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("CrossBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("ReinforcedBurstBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(6, 0), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(-6, 0), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(0, 6), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(0, -6), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 60, Projectile.position.Y), new Vector2(-6, 0), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage, 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 60, Projectile.position.Y), new Vector2(6, 0), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage, 1f, Projectile.owner);
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y + 60), new Vector2(0, -6), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage, 1f, Projectile.owner);
                    int h = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y - 60), new Vector2(0, 6), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("CrossBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("LinearBurstBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(8, 0), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(-8, 0), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(0, 8), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(0, -8), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 60, Projectile.position.Y), new Vector2(-8, 0), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage, 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 60, Projectile.position.Y), new Vector2(8, 0), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage, 1f, Projectile.owner);
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y + 60), new Vector2(0, -8), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage, 1f, Projectile.owner);
                    int h = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y - 60), new Vector2(0, 8), Mod.Find<ModProjectile>("BoomSkullburst").Type, Projectile.damage, 1f, Projectile.owner);
                }
            }
        }
	}
}