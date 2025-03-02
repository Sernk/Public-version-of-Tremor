using System;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using TremorMod;
using TremorMod.Content.Buffs;
using TremorMod.Utilities;
using Utils = Terraria.Utils;

namespace TremorMod.Content.Projectiles
{
	public class BasicFlaskPro : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
		}

        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 28;
            Projectile.friendly = true;
            Projectile.aiStyle = 2;
            Projectile.penetrate = 1; // Устанавливаем стандартное значение
            Projectile.timeLeft = 1200;
            Projectile.scale = 1f;
        }

        // Код выполняется после спавна
        public override void OnSpawn(IEntitySource source)
        {
            Player player = Main.player[Projectile.owner];

            if (player.HasBuff(ModContent.BuffType<BouncingCasingBuff>()))
            {
                Projectile.penetrate = 3;
            }
        }


        public static class Helper
        {
            public static Vector2 RandomPointInArea(Vector2 topLeft, Vector2 bottomRight)
            {
                float x = Main.rand.NextFloat(topLeft.X, bottomRight.X);
                float y = Main.rand.NextFloat(topLeft.Y, bottomRight.Y);
                return new Vector2(x, y);
            }

            public static Vector2 VelocityToPoint(Vector2 startPoint, Vector2 endPoint, float speed)
            {
                Vector2 direction = endPoint - startPoint;
                direction.Normalize();
                return direction * speed;
            }
        }

        public override void AI()
		{
            if (Main.LocalPlayer.HasBuff(Mod.Find<ModBuff>("TheCadenceBuff").Type))
            {
                int[] array = new int[20];
                int num428 = 0;
                float num429 = 495f;
                //bool flag14 = false;

                // Переменные для хранения координат цели
                float num435 = 0f;
                float num436 = 0f;

                for (int num430 = 0; num430 < 200; num430++)
                {
                    if (Main.npc[num430].CanBeChasedBy(Projectile, false))
                    {
                        float num431 = Main.npc[num430].position.X + Main.npc[num430].width / 2;
                        float num432 = Main.npc[num430].position.Y + Main.npc[num430].height / 2;
                        float num433 = Math.Abs(Projectile.position.X + Projectile.width / 2 - num431) +
                                       Math.Abs(Projectile.position.Y + Projectile.height / 2 - num432);

                        if (num433 < num429 && Collision.CanHit(Projectile.Center, 1, 1, Main.npc[num430].Center, 1, 1))
                        {
                            if (num428 < 20)
                            {
                                array[num428] = num430;
                                num428++;
                            }

                            // Установим координаты цели (например, первого найденного NPC)
                            num435 = num431;
                            num436 = num432;

                            //flag14 = true;
                        }
                    }
                }

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
                        // Создаем источник сущности.
                        var entitySource = Projectile.GetSource_FromThis();

                        // Передаем исправленные аргументы.
                        Projectile.NewProjectile(
                            entitySource,                         // Источник
                            value10,                              // Позиция (Vector2)
                            new Vector2(num438, num439),          // Скорость (Vector2)
                            Mod.Find<ModProjectile>("TheCadenceProj").Type,
                            (int)Projectile.damage,               // Урон (int)
                            Projectile.knockBack,                 // Отбрасывание
                            (int)Projectile.owner,                // Владелец (int)
                            0f,
                            0f
                        );
                    }
                }
            }

        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Player player = Main.player[Projectile.owner];

            if (player.HasBuff(ModContent.BuffType<BouncingCasingBuff>()))
            {
                // Проверка на бесконечное проникновение
                if (Projectile.penetrate > 0)
                {
                    Projectile.penetrate--;
                }

                if (Projectile.penetrate == 0)
                {
                    Projectile.Kill();
                    return false;
                }

                // Отскок только в направлении удара
                if (Projectile.velocity.X != oldVelocity.X)
                {
                    Projectile.velocity.X = -oldVelocity.X * 0.8f; // Коэффициент потери скорости
                }
                if (Projectile.velocity.Y != oldVelocity.Y)
                {
                    Projectile.velocity.Y = -oldVelocity.Y * 0.8f;
                }

                SoundEngine.PlaySound(SoundID.Item10);
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
            SoundEngine.PlaySound(SoundID.Item107, Projectile.position);

            IEntitySource source = Projectile.GetSource_FromThis();
            Gore.NewGore(source, Projectile.position, -Projectile.oldVelocity * 0.2f, 704, 1f);
            Gore.NewGore(source, Projectile.position, -Projectile.oldVelocity * 0.2f, 705, 1f);

            var entitySource = Projectile.GetSource_FromThis(); // Источник сущности

            if (player.HasBuff(Mod.Find<ModBuff>("PyroBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("NitroBuff").Type))
            {
                if (Projectile.owner == Main.myPlayer)
                {
                    int num220 = Main.rand.Next(3, 6);
                    for (int num221 = 0; num221 < num220; num221++)
                    {
                        Vector2 value17 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                        value17.Normalize();
                        value17 *= Main.rand.Next(10, 201) * 0.01f;

                        Projectile.NewProjectile(
                            entitySource,
                            Projectile.position,
                            value17, // Vector2 скорость
                            Mod.Find<ModProjectile>("CloudPro").Type,
                            (int)Projectile.damage, // int
                            1f,
                            Projectile.owner,
                            0f,
                            Main.rand.Next(-45, 1) // int
                        );
                    }
                }

                if (player.HasBuff(Mod.Find<ModBuff>("BrassChipBuff").Type))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Vector2 vector2 = new Vector2(
                            player.position.X + 75f * (float)Math.Cos(12),
                            player.position.Y + 1075f * (float)Math.Sin(12)
                        );

                        Vector2 velocity = Helper.VelocityToPoint(
                            vector2,
                            Helper.RandomPointInArea(
                                new Vector2(Projectile.Center.X - 10, Projectile.Center.Y - 10),
                                new Vector2(Projectile.Center.X + 20, Projectile.Center.Y + 20)
                            ),
                            24
                        );

                        int a = Projectile.NewProjectile(
                            entitySource,
                            vector2,
                            velocity,
                            134,
                            (int)Projectile.damage, 
                            1f,
                            Projectile.owner
                        );
                        Main.projectile[a].friendly = true;
                    }
                }

                if (player.HasBuff(Mod.Find<ModBuff>("ChaosElementBuff").Type))
                {
                    int num220 = Main.rand.Next(3, 6);
                    for (int num221 = 0; num221 < num220; num221++)
                    {
                        Vector2 value17 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                        value17.Normalize();
                        value17 *= Main.rand.Next(10, 201) * 0.01f;

                        Projectile.NewProjectile(
                            entitySource,
                            Projectile.position,
                            value17,
                            Mod.Find<ModProjectile>("Shatter1").Type,
                            (int)Projectile.damage, 
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
                if (player.HasBuff(Mod.Find<ModBuff>("DesertEmperorSetBuff").Type))
                {
                    Vector2 position = Projectile.position;
                    Vector2 velocity = Vector2.Zero;
                    int a = Projectile.NewProjectile(entitySource, position, velocity,
                    Mod.Find<ModProjectile>("FlaskWasp").Type,
                    Projectile.damage * 2, 1.5f, Projectile.owner);
                    int b = Projectile.NewProjectile(entitySource, position, velocity,
                    Mod.Find<ModProjectile>("FlaskWasp").Type,
                    Projectile.damage * 2, 1.5f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("PyroBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("NitroBuff").Type))
                {
                    Vector2 position = Projectile.position;
                    Vector2 velocity = Vector2.Zero;
                    SoundEngine.PlaySound(SoundID.Item62);
                    int a = Projectile.NewProjectile(entitySource, position, velocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type,
                    Projectile.damage * 2, 1.5f, Projectile.owner);

                    Main.projectile[a].scale = 1.5f;
                }
                if (player.HasBuff(Mod.Find<ModBuff>("ChemikazeBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("NitroBuff").Type))
                {
                    Vector2 position = Projectile.position;
                    Vector2 velocity = Vector2.Zero;
                    SoundEngine.PlaySound(SoundID.Item62);
                    int a = Projectile.NewProjectile(entitySource, position, velocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type,
                    Projectile.damage * 2, 1.25f, Projectile.owner);
                    Main.projectile[a].scale = 1.25f;
                    int b = Projectile.NewProjectile(entitySource, position + new Vector2(32, 0), velocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type,
                    Projectile.damage * 2, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(entitySource, position + new Vector2(-32, 0), velocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type,
                    Projectile.damage * 2, 1f, Projectile.owner);

                    int d = Projectile.NewProjectile(entitySource, position + new Vector2(0, 32), velocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type,
                    Projectile.damage * 2, 1f, Projectile.owner);

                    int e = Projectile.NewProjectile(entitySource, position + new Vector2(0, -32), velocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type,
                    Projectile.damage * 2, 1f, Projectile.owner);
                }

                if (player.HasBuff(Mod.Find<ModBuff>("CrossBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("NitroBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62);
                    Vector2 position = Projectile.position;
                    Vector2 zeroVelocity = Vector2.Zero;
                    int a = Projectile.NewProjectile(entitySource, position, zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type,
                    Projectile.damage * 2, 1.25f, Projectile.owner);
                    Main.projectile[a].scale = 1.25f;
                    int b = Projectile.NewProjectile(entitySource, position + new Vector2(30, 0), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type,
                    Projectile.damage * 2, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(entitySource, position + new Vector2(-30, 0), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type,
                    Projectile.damage * 2, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(entitySource, position + new Vector2(0, 30), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type,
                    Projectile.damage * 2, 1f, Projectile.owner);
					int e = Projectile.NewProjectile(entitySource, position + new Vector2(0, -30), zeroVelocity,
					Mod.Find<ModProjectile>("BasicBlast").Type,
					Projectile.damage * 2, 1f, Projectile.owner);
					int f = Projectile.NewProjectile(entitySource, position + new Vector2(50, 0), zeroVelocity,
					Mod.Find<ModProjectile>("BasicBlast").Type,
					Projectile.damage * 2, 0.7f, Projectile.owner);
					int g = Projectile.NewProjectile(entitySource, position + new Vector2(-50, 0), zeroVelocity,
					Mod.Find<ModProjectile>("BasicBlast").Type,
					Projectile.damage * 2, 0.7f, Projectile.owner);
					int h = Projectile.NewProjectile(entitySource, position + new Vector2(0, 50), zeroVelocity,
					Mod.Find<ModProjectile>("BasicBlast").Type,
					Projectile.damage * 2, 0.7f, Projectile.owner);
                    int i = Projectile.NewProjectile(entitySource, position + new Vector2(0, -50), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type,
                    Projectile.damage * 2, 0.7f, Projectile.owner);
					int j = Projectile.NewProjectile(entitySource, position + new Vector2(+70, 0), zeroVelocity,
					Mod.Find<ModProjectile>("BasicBlast").Type,
					Projectile.damage * 2, 0.5f, Projectile.owner);
					int k = Projectile.NewProjectile(entitySource, position + new Vector2(-70, 0), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type,
                     Projectile.damage * 2, 0.5f, Projectile.owner);
					int l = Projectile.NewProjectile(entitySource, position + new Vector2(+70, 0), zeroVelocity,
					Mod.Find<ModProjectile>("BasicBlast").Type,
					Projectile.damage * 2, 0.5f, Projectile.owner);
                    int m = Projectile.NewProjectile(entitySource, position + new Vector2(-70, 0), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type,
                    Projectile.damage * 2, 0.5f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("RoundBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("NitroBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62);
                    Vector2 position = Projectile.position;
                    Vector2 zeroVelocity = Vector2.Zero;
                    int a = Projectile.NewProjectile(entitySource, position + new Vector2(60, 0), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type,
                    Projectile.damage * 2, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(entitySource, position + new Vector2(-60, 0), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type,
                    Projectile.damage * 2, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(entitySource, position + new Vector2(0, 60), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type,
                    Projectile.damage * 2, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(entitySource, position + new Vector2(0, -60), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type,
                    Projectile.damage * 2, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(entitySource, position + new Vector2(40, 40), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type,
                    Projectile.damage * 2, 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(entitySource, position + new Vector2(-40, 40), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type,
                    Projectile.damage * 2, 1f, Projectile.owner);
                    int g = Projectile.NewProjectile(entitySource, position + new Vector2(40, -40), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type,
                    Projectile.damage * 2, 1f, Projectile.owner);
                    int h = Projectile.NewProjectile(entitySource, position + new Vector2(-40, -40), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type,
                    Projectile.damage * 2, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("SquareBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("NitroBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62);
                    Vector2 position = Projectile.position; 
                    Vector2 zeroVelocity = Vector2.Zero;    
                    int a = Projectile.NewProjectile(entitySource, position + new Vector2(70, 0), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(entitySource, position + new Vector2(-70, 0), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(entitySource, position + new Vector2(0, 70), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(entitySource, position + new Vector2(0, -70), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(entitySource, position + new Vector2(70, 70), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(entitySource, position + new Vector2(-70, 70), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int g = Projectile.NewProjectile(entitySource, position + new Vector2(70, -70), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int h = Projectile.NewProjectile(entitySource, position + new Vector2(-70, -70), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("NitroBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("PyroBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item100);
                    Vector2 position = Projectile.position; 
                    Vector2 zeroVelocity = Vector2.Zero;    
                    int a = Projectile.NewProjectile(entitySource, position, zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBurst").Type, Projectile.damage, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("ReinforcedBurstBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("PyroBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item100);
                    Vector2 position = Projectile.position;
                    Vector2 zeroVelocity = Vector2.Zero;
                    int a = Projectile.NewProjectile(entitySource, position, zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(entitySource, position + new Vector2(50, 0), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(entitySource, position + new Vector2(-50, 0), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBurst").Type, Projectile.damage, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("LinearBurstBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("PyroBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item100);
                    Vector2 position = Projectile.position;
                    Vector2 zeroVelocity = Vector2.Zero;
                    int a = Projectile.NewProjectile(entitySource, position, zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(entitySource, position + new Vector2(50, 0), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(entitySource, position + new Vector2(-50, 0), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(entitySource, position + new Vector2(100, 0), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(entitySource, position + new Vector2(-100, 0), zeroVelocity,
                    Mod.Find<ModProjectile>("BasicBurst").Type, Projectile.damage, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("NitroBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("PyroBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item42);
                    Vector2 position = Projectile.position;
                    int a = Projectile.NewProjectile(entitySource, position, Vector2.Zero, 
                    Mod.Find<ModProjectile>("BasicBlast").Type, Projectile.damage * 2, 1.5f, Projectile.owner);
                    Main.projectile[a].scale = 1.5f;
                    int b = Projectile.NewProjectile(entitySource, position + new Vector2(20, 0), new Vector2(5, 0), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(entitySource, position + new Vector2(-20, 0), new Vector2(-5, 0), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("ReinforcedBurstBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("PyroBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item42);
                    Vector2 position = Projectile.position;
                    int a = Projectile.NewProjectile(entitySource, position, Vector2.Zero, 
                    Mod.Find<ModProjectile>("BasicBlast").Type, Projectile.damage * 2, 1.5f, Projectile.owner);
                    Main.projectile[a].scale = 1.5f;
                    int b = Projectile.NewProjectile(entitySource, position + new Vector2(10, -10), new Vector2(6, 0), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(entitySource, position + new Vector2(-10, -10), new Vector2(-6, 0), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(entitySource, position + new Vector2(40, 10), new Vector2(4, 0), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(entitySource, position + new Vector2(-40, 10), new Vector2(-4, 0), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("LinearBurstBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("PyroBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item42);
                    Vector2 position = Projectile.position;
                    int a = Projectile.NewProjectile(entitySource, position, Vector2.Zero, 
                    Mod.Find<ModProjectile>("BasicBlast").Type, Projectile.damage * 2, 1.5f, Projectile.owner);
                    Main.projectile[a].scale = 1.5f;
                    int b = Projectile.NewProjectile(entitySource, position + new Vector2(10, -15), new Vector2(6, 0), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(entitySource, position + new Vector2(-10, -15), new Vector2(-6, 0), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(entitySource, position + new Vector2(40, 0), new Vector2(5, 0), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(entitySource, position + new Vector2(-40, 0), new Vector2(-5, 0), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(entitySource, position + new Vector2(70, 15), new Vector2(4, 0), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int g = Projectile.NewProjectile(entitySource, position + new Vector2(-70, 15), new Vector2(-4, 0), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("RoundBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("NitroBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62);
                    Vector2 position = Projectile.position;
                    int z = Projectile.NewProjectile(entitySource, position, Vector2.Zero, 
                    Mod.Find<ModProjectile>("BasicBlast").Type, Projectile.damage * 2, 1.5f, Projectile.owner);
                    Main.projectile[z].scale = 1.25f;
                    int a = Projectile.NewProjectile(entitySource, position + new Vector2(25, 0), new Vector2(4, 0), 
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(entitySource, position + new Vector2(-25, 0), new Vector2(-4, 0), 
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(entitySource, position + new Vector2(0, 25), new Vector2(0, 4), 
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(entitySource, position + new Vector2(0, -25), new Vector2(0, -4), 
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(entitySource, position + new Vector2(20, 20), new Vector2(4, 4), 
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[e].scale = 0.8f;
                    int f = Projectile.NewProjectile(entitySource, position + new Vector2(-20, 20), new Vector2(-4, 4), 
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[f].scale = 0.8f;
                    int g = Projectile.NewProjectile(entitySource, position + new Vector2(20, -20), new Vector2(4, -4), 
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[g].scale = 0.8f;
                    int h = Projectile.NewProjectile(entitySource, position + new Vector2(-20, -20), new Vector2(-4, -4), 
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[h].scale = 0.8f;
                }
                if (player.HasBuff(Mod.Find<ModBuff>("RoundBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("ReinforcedBurstBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62);
                    Vector2 position = Projectile.position;
                    int z = Projectile.NewProjectile(entitySource, position, Vector2.Zero, 
                    Mod.Find<ModProjectile>("BasicBlast").Type, Projectile.damage * 2, 1.5f, Projectile.owner);
                    Main.projectile[z].scale = 1.25f;
                    int a = Projectile.NewProjectile(entitySource, position + new Vector2(65, 0), new Vector2(3, 0), 
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(entitySource, position + new Vector2(-65, 0), new Vector2(-3, 0), 
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(entitySource, position + new Vector2(0, 35), new Vector2(0, 4), 
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(entitySource, position + new Vector2(0, -35), new Vector2(0, -4), 
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(entitySource, position + new Vector2(50, 20), new Vector2(0, 4), 
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[e].scale = 1.2f;
                    int f = Projectile.NewProjectile(entitySource, position + new Vector2(-50, 20), new Vector2(0, 4), 
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[f].scale = 1.2f;
                    int g = Projectile.NewProjectile(entitySource, position + new Vector2(50, -20), new Vector2(0, -4), 
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[g].scale = 1.2f;
                    int h = Projectile.NewProjectile(entitySource, position + new Vector2(-50, -20), new Vector2(0, -4), 
                     Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[h].scale = 1.2f;
                }

                if (player.HasBuff(Mod.Find<ModBuff>("RoundBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("LinearBurstBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62);
                    Vector2 position = Projectile.position;
                    int z = Projectile.NewProjectile(entitySource, position, Vector2.Zero, 
                    Mod.Find<ModProjectile>("BasicBlast").Type, Projectile.damage * 2, 1.5f, Projectile.owner);
                    Main.projectile[z].scale = 1.25f;
                    int a = Projectile.NewProjectile(entitySource, position + new Vector2(65, 0), new Vector2(3, 0), 
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(entitySource, position + new Vector2(-65, 0), new Vector2(-3, 0), 
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(entitySource, position + new Vector2(0, 35), new Vector2(0, 4), 
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(entitySource, position + new Vector2(0, -35), new Vector2(0, -4), 
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(entitySource, position + new Vector2(50, 20), new Vector2(0, 4), 
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[e].scale = 0.8f;
                    int f = Projectile.NewProjectile(entitySource, position + new Vector2(-50, 20), new Vector2(0, 4),
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[f].scale = 0.8f;
                    int g = Projectile.NewProjectile(entitySource, position + new Vector2(50, -20), new Vector2(0, -4), 
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[g].scale = 0.8f;
                    int h = Projectile.NewProjectile(entitySource, position + new Vector2(-50, -20), new Vector2(0, -4), 
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[h].scale = 0.8f;
                    int i = Projectile.NewProjectile(entitySource, position + new Vector2(80, 20), new Vector2(0, 4), 
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[i].scale = 0.6f;
                    int k = Projectile.NewProjectile(entitySource, position + new Vector2(-80, 20), new Vector2(0, 4), 
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[k].scale = 0.6f;
                    int l = Projectile.NewProjectile(entitySource, position + new Vector2(80, -20), new Vector2(0, -4), 
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[l].scale = 0.6f;
                    int m = Projectile.NewProjectile(entitySource, position + new Vector2(-80, -20), new Vector2(0, -4), 
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[m].scale = 0.6f;
                }
                if (player.HasBuff(Mod.Find<ModBuff>("SquareBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("NitroBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62);
                    Vector2 position = Projectile.position; 
                    int d = Projectile.NewProjectile(entitySource, position, Vector2.Zero,
                    Mod.Find<ModProjectile>("BasicBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[d].scale = 1.5f;
                    int e = Projectile.NewProjectile(entitySource, position + new Vector2(30, 30), new Vector2(3, 3), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(entitySource, position + new Vector2(-30, 30), new Vector2(-3, 3), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int g = Projectile.NewProjectile(entitySource, position + new Vector2(30, -30), new Vector2(3, -3), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int h = Projectile.NewProjectile(entitySource, position + new Vector2(-30, -30), new Vector2(-3, -3), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("SquareBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("ReinforcedBurstBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62);
                    Vector2 position = Projectile.position; 
                    int d = Projectile.NewProjectile(entitySource, position, Vector2.Zero, 
                    Mod.Find<ModProjectile>("BasicBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[d].scale = 1.5f;
                    int e = Projectile.NewProjectile(entitySource, position + new Vector2(30, 30), new Vector2(2, 3), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[e].scale = 0.75f;
                    int f = Projectile.NewProjectile(entitySource, position + new Vector2(-30, 30), new Vector2(-2, 3), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[f].scale = 0.75f;
                    int g = Projectile.NewProjectile(entitySource, position + new Vector2(30, -30), new Vector2(2, -3), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[g].scale = 0.75f;
                    int h = Projectile.NewProjectile(entitySource, position + new Vector2(-30, -30), new Vector2(-2, -3), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[h].scale = 0.75f;
                    int i = Projectile.NewProjectile(entitySource, position + new Vector2(30, 30), new Vector2(3, 2), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[i].scale = 0.75f;
                    int j = Projectile.NewProjectile(entitySource, position + new Vector2(-30, 30), new Vector2(-3, 2), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[j].scale = 0.75f;
                    int k = Projectile.NewProjectile(entitySource, position + new Vector2(30, -30), new Vector2(3, -2), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[k].scale = 0.75f;
                    int l = Projectile.NewProjectile(entitySource, position + new Vector2(-30, -30), new Vector2(-3, -2),
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[l].scale = 0.75f;
                }
                if (player.HasBuff(Mod.Find<ModBuff>("SquareBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("LinearBurstBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62);
                    Vector2 position = Projectile.position;
                    int d = Projectile.NewProjectile(entitySource, position, Vector2.Zero,
                    Mod.Find<ModProjectile>("BasicBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[d].scale = 1.5f;
                    int e = Projectile.NewProjectile(entitySource, position + new Vector2(30, 30), new Vector2(2, 4), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[e].scale = 0.65f;
                    int f = Projectile.NewProjectile(entitySource, position + new Vector2(-30, 30), new Vector2(-2, 4), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[f].scale = 0.65f;
                    int g = Projectile.NewProjectile(entitySource, position + new Vector2(30, -30), new Vector2(2, -4), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[g].scale = 0.65f;
                    int h = Projectile.NewProjectile(entitySource, position + new Vector2(-30, -30), new Vector2(-2, -4), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[h].scale = 0.65f;
                    int i = Projectile.NewProjectile(entitySource, position + new Vector2(30, 30), new Vector2(4, 2), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[i].scale = 0.65f;
                    int j = Projectile.NewProjectile(entitySource, position + new Vector2(-30, 30), new Vector2(-4, 2), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[j].scale = 0.65f;
                    int k = Projectile.NewProjectile(entitySource, position + new Vector2(30, -30), new Vector2(4, -2), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[k].scale = 0.65f;
                    int l = Projectile.NewProjectile(entitySource, position + new Vector2(-30, -30), new Vector2(-4, -2), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[l].scale = 0.65f;
                    int m = Projectile.NewProjectile(entitySource, position + new Vector2(30, 30), new Vector2(3, 3), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[m].scale = 0.7f;
                    int n = Projectile.NewProjectile(entitySource, position + new Vector2(-30, 30), new Vector2(-3, 3), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[n].scale = 0.7f;
                    int o = Projectile.NewProjectile(entitySource, position + new Vector2(30, -30), new Vector2(3, -3), 
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[o].scale = 0.7f;
                    int p = Projectile.NewProjectile(entitySource, position + new Vector2(-30, -30), new Vector2(-3, -3),
                    Mod.Find<ModProjectile>("BasicSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[p].scale = 0.7f;
                }
                if (player.HasBuff(Mod.Find<ModBuff>("NitroBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("ChemikazeBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item100);
                    Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X - 30, Projectile.position.Y), new Vector2(-2, 0),
                    Mod.Find<ModProjectile>("BasicBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X + 30, Projectile.position.Y), new Vector2(2, 0),
                    Mod.Find<ModProjectile>("BasicBurst").Type, Projectile.damage, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("ReinforcedBurstBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("ChemikazeBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item100);
                    Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X - 40, Projectile.position.Y), new Vector2(-2, 0),
                    Mod.Find<ModProjectile>("BasicBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X + 40, Projectile.position.Y), new Vector2(2, 0),
                    Mod.Find<ModProjectile>("BasicBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X - 60, Projectile.position.Y), new Vector2(-3, 0),
                    Mod.Find<ModProjectile>("BasicBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X + 60, Projectile.position.Y), new Vector2(3, 0),
                    Mod.Find<ModProjectile>("BasicBurst").Type, Projectile.damage, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("LinearBurstBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("ChemikazeBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item100);
                    Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X - 40, Projectile.position.Y), new Vector2(-2, 0),
                    Mod.Find<ModProjectile>("BasicBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X + 40, Projectile.position.Y), new Vector2(2, 0),
                    Mod.Find<ModProjectile>("BasicBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X - 60, Projectile.position.Y), new Vector2(-3, 0),
                    Mod.Find<ModProjectile>("BasicBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X + 60, Projectile.position.Y), new Vector2(3, 0),
                    Mod.Find<ModProjectile>("BasicBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X - 80, Projectile.position.Y), new Vector2(-4, 0),
                    Mod.Find<ModProjectile>("BasicBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X + 80, Projectile.position.Y), new Vector2(4, 0),
                    Mod.Find<ModProjectile>("BasicBurst").Type, Projectile.damage, 1f, Projectile.owner);
                }

                if (player.HasBuff(Mod.Find<ModBuff>("CrossBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("NitroBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62);
                    int a = Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(4, 0),
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(-4, 0),
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(0, 4),
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(0, -4),
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X + 60, Projectile.position.Y), new Vector2(-4, 0),
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage, 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X - 60, Projectile.position.Y), new Vector2(4, 0),
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage, 1f, Projectile.owner);
                    int g = Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X, Projectile.position.Y + 60), new Vector2(0, -4),
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage, 1f, Projectile.owner);
                    int h = Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X, Projectile.position.Y - 60), new Vector2(0, 4),
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("CrossBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("ReinforcedBurstBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62);
                    int a = Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(6, 0),
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(-6, 0),
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(0, 6),
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(0, -6),
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X + 60, Projectile.position.Y), new Vector2(-6, 0),
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X - 60, Projectile.position.Y), new Vector2(6, 0),
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int g = Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X, Projectile.position.Y + 60), new Vector2(0, -6),
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int h = Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X, Projectile.position.Y - 60), new Vector2(0, 6),
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                }

                if (player.HasBuff(Mod.Find<ModBuff>("CrossBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("LinearBurstBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62);
                    int a = Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(8, 0),
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(-8, 0),
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(0, 8),
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(0, -8),
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X + 60, Projectile.position.Y), new Vector2(-8, 0),
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X - 60, Projectile.position.Y), new Vector2(8, 0),
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int g = Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X, Projectile.position.Y + 60), new Vector2(0, -8),
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int h = Projectile.NewProjectile(entitySource, new Vector2(Projectile.position.X, Projectile.position.Y - 60), new Vector2(0, 8),
                    Mod.Find<ModProjectile>("BasicSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                }
            }
        }
	}
}