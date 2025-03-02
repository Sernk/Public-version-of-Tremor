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
using Utils = Terraria.Utils;

namespace TremorMod.Content.Projectiles
{
	public class LesserHealingFlackPro : ModProjectile
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
			Projectile.timeLeft = 1200;
			Projectile.penetrate = 1;
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
            if (Main.LocalPlayer.HasBuff(Mod.Find<ModBuff>("TheCadenceBuff").Type))
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
                        float num433 = Math.Abs(Projectile.position.X + Projectile.width / 2 - num431) +
                                       Math.Abs(Projectile.position.Y + Projectile.height / 2 - num432);
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

                        Vector2 spawnPosition = new Vector2(Projectile.position.X + Projectile.width * 0.5f,
                                                            Projectile.position.Y + Projectile.height * 0.5f);
                        spawnPosition += Projectile.velocity * 4f;

                        float num438 = num435 - spawnPosition.X;
                        float num439 = num436 - spawnPosition.Y;
                        float num440 = (float)Math.Sqrt(num438 * num438 + num439 * num439);
                        num440 = num437 / num440;
                        Vector2 velocity = new Vector2(num438 * num440, num439 * num440);

                        if (Terraria.Utils.NextBool(Main.rand, 2))
                        {
                            IEntitySource source = Projectile.GetSource_FromThis();
                            Projectile.NewProjectile(source, spawnPosition, velocity,
                                Mod.Find<ModProjectile>("TheCadenceProj").Type, Projectile.damage, Projectile.knockBack, Projectile.owner);
                        }
                    }
                }
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

            public static Vector2 VelocityToPoint(Vector2 start, Vector2 end, float speed)
            {
                Vector2 direction = end - start;
                direction.Normalize();
                return direction * speed;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (Main.LocalPlayer.HasBuff(Mod.Find<ModBuff>("BouncingCasingBuff").Type))
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
					SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
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
            SoundEngine.PlaySound(SoundID.Item107, Projectile.position);

            IEntitySource source = Projectile.GetSource_FromThis();
            Gore.NewGore(source, Projectile.position, -Projectile.oldVelocity * 0.2f, 704, 1f);
            Gore.NewGore(source, Projectile.position, -Projectile.oldVelocity * 0.2f, 705, 1f);

            if (player.HasBuff(Mod.Find<ModBuff>("BrassChipBuff").Type))
            {
                for (int i = 0; i < 5; i++)
                {
                    Vector2 spawnPosition = new Vector2(
                        player.position.X + 75f * (float)Math.Cos(12),
                        player.position.Y + 1075f * (float)Math.Sin(12)
                    );

                    Vector2 targetPosition = Helper.RandomPointInArea(
                        new Vector2(Projectile.Center.X - 10, Projectile.Center.Y - 10),
                        new Vector2(Projectile.Center.X + 20, Projectile.Center.Y + 20)
                    );

                    Vector2 velocity = Helper.VelocityToPoint(spawnPosition, targetPosition, 24f);

                    int projectileIndex = Projectile.NewProjectile(
                        source,
                        spawnPosition,
                        velocity,
                        134, 
                        Projectile.damage,
                        1f,  
                        Projectile.owner
                    );

                    Main.projectile[projectileIndex].friendly = true;
                }
            }
            if (player.HasBuff(Mod.Find<ModBuff>("ChaosElementBuff").Type))
            {
                int num220 = Main.rand.Next(3, 6);
                for (int num221 = 0; num221 < num220; num221++)
                {
                    Vector2 velocity = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                    velocity.Normalize();
                    velocity *= Main.rand.Next(10, 201) * 0.01f;
                    Projectile.NewProjectile(
                        source,
                        Projectile.position,
                        velocity,
                        Mod.Find<ModProjectile>("Shatter1").Type,
                        Projectile.damage,
                        1f,
                        Projectile.owner,
                        0f,
                        Main.rand.Next(-45, 1)
                    );
                }
            }

            if (!modPlayer.pyro && !modPlayer.nitro)
            {
                if (Projectile.owner == Main.myPlayer)
                {
                    int num220 = Main.rand.Next(3, 6);
                    for (int num221 = 0; num221 < num220; num221++)
                    {
                        Vector2 velocity = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                        velocity.Normalize();
                        velocity *= Main.rand.Next(10, 201) * 0.01f;
                        Projectile.NewProjectile(
                            source,
                            Projectile.position,
                            velocity,
                            ModContent.ProjectileType<HealingCloudPro>(),
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
                if (player.HasBuff(Mod.Find<ModBuff>("DesertEmperorSetBuff").Type))
                {
                    int a = Projectile.NewProjectile(
                        source,
                        Projectile.position,
                        Vector2.Zero, 
                        Mod.Find<ModProjectile>("FlaskWasp").Type,
                        Projectile.damage * 2,
                        1.5f,
                        Projectile.owner
                    );
                    int b = Projectile.NewProjectile(
                        source,
                        Projectile.position,
                        Vector2.Zero, 
                        Mod.Find<ModProjectile>("FlaskWasp").Type,
                        Projectile.damage * 2,
                        1.5f,
                        Projectile.owner
                    );
                }
                if (player.HasBuff(Mod.Find<ModBuff>("PyroBuff").Type) && !modPlayer.nitro)
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    int a = Projectile.NewProjectile(
                        source,
                        Projectile.position,
                        Vector2.Zero, 
                        Mod.Find<ModProjectile>("HealingBlast").Type,
                        Projectile.damage * 2,
                        1.5f,
                        Projectile.owner
                    );
                    Main.projectile[a].scale = 1.5f;
                }
                if (player.HasBuff(Mod.Find<ModBuff>("ChemikazeBuff").Type) && !modPlayer.nitro)
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    int a = Projectile.NewProjectile(
                        source,
                        Projectile.position,
                        Vector2.Zero, 
                        Mod.Find<ModProjectile>("HealingBlast").Type,
                        Projectile.damage * 2,
                        1.25f,
                        Projectile.owner
                    );
                    Main.projectile[a].scale = 1.25f;
                    int b = Projectile.NewProjectile(
                        source,
                        new Vector2(Projectile.position.X + 32, Projectile.position.Y),
                        Vector2.Zero, 
                        Mod.Find<ModProjectile>("HealingBlast").Type,
                        Projectile.damage * 2,
                        1f,
                        Projectile.owner
                    );
                    int c = Projectile.NewProjectile(
                        source,
                        new Vector2(Projectile.position.X - 32, Projectile.position.Y),
                        Vector2.Zero, 
                        Mod.Find<ModProjectile>("HealingBlast").Type,
                        Projectile.damage * 2,
                        1f,
                        Projectile.owner
                    );
                    int d = Projectile.NewProjectile(
                        source,
                        new Vector2(Projectile.position.X, Projectile.position.Y + 32),
                        Vector2.Zero, 
                        Mod.Find<ModProjectile>("HealingBlast").Type,
                        Projectile.damage * 2,
                        1f,
                        Projectile.owner
                    );
                    int e = Projectile.NewProjectile(
                        source,
                        new Vector2(Projectile.position.X, Projectile.position.Y - 32),
                        Vector2.Zero, 
                        Mod.Find<ModProjectile>("HealingBlast").Type,
                        Projectile.damage * 2,
                        1f,
                        Projectile.owner
                    );
                }
                if (player.HasBuff(Mod.Find<ModBuff>("CrossBlastBuff").Type) && !modPlayer.nitro)
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    int a = Projectile.NewProjectile(
                        source,
                        Projectile.position,
                        Vector2.Zero,  
                        Mod.Find<ModProjectile>("HealingBlast").Type,
                        Projectile.damage * 2,
                        1.25f,
                        Projectile.owner
                    );
                    Main.projectile[a].scale = 1.25f;
                    int b = Projectile.NewProjectile(
                        source,
                        new Vector2(Projectile.position.X + 30, Projectile.position.Y),
                        Vector2.Zero,  
                        Mod.Find<ModProjectile>("HealingBlast").Type,
                        Projectile.damage * 2,
                        1f,
                        Projectile.owner
                    );
                    int c = Projectile.NewProjectile(
                        source,
                        new Vector2(Projectile.position.X - 30, Projectile.position.Y),
                        Vector2.Zero,  
                        Mod.Find<ModProjectile>("HealingBlast").Type,
                        Projectile.damage * 2,
                        1f,
                        Projectile.owner
                    );
                    int d = Projectile.NewProjectile(
                        source,
                        new Vector2(Projectile.position.X, Projectile.position.Y + 30),
                        Vector2.Zero,  
                        Mod.Find<ModProjectile>("HealingBlast").Type,
                        Projectile.damage * 2,
                        1f,
                        Projectile.owner
                    );
                    int e = Projectile.NewProjectile(
                        source,
                        new Vector2(Projectile.position.X, Projectile.position.Y - 30),
                        Vector2.Zero,  
                        Mod.Find<ModProjectile>("HealingBlast").Type,
                        Projectile.damage * 2,
                        1f,
                        Projectile.owner
                    );
                    int f = Projectile.NewProjectile(
                        source,
                        new Vector2(Projectile.position.X + 50, Projectile.position.Y),
                        Vector2.Zero,  
                        Mod.Find<ModProjectile>("HealingBlast").Type,
                        Projectile.damage * 2,
                        0.7f,
                        Projectile.owner
                    );
                    Main.projectile[f].scale = 0.7f;
                    int g = Projectile.NewProjectile(
                        source,
                        new Vector2(Projectile.position.X - 50, Projectile.position.Y),
                        Vector2.Zero,  
                        Mod.Find<ModProjectile>("HealingBlast").Type,
                        Projectile.damage * 2,
                        0.7f,
                        Projectile.owner
                    );
                    Main.projectile[g].scale = 0.7f;
                    int h = Projectile.NewProjectile(
                        source,
                        new Vector2(Projectile.position.X, Projectile.position.Y + 50),
                        Vector2.Zero,  
                        Mod.Find<ModProjectile>("HealingBlast").Type,
                        Projectile.damage * 2,
                        0.7f,
                        Projectile.owner
                    );
                    Main.projectile[h].scale = 0.7f;
                    int i = Projectile.NewProjectile(
                        source,
                        new Vector2(Projectile.position.X, Projectile.position.Y - 50),
                        Vector2.Zero,  
                        Mod.Find<ModProjectile>("HealingBlast").Type,
                        Projectile.damage * 2,
                        0.7f,
                        Projectile.owner
                    );
                    Main.projectile[i].scale = 0.7f;
                    int j = Projectile.NewProjectile(
                        source,
                        new Vector2(Projectile.position.X + 70, Projectile.position.Y),
                        Vector2.Zero,  
                        Mod.Find<ModProjectile>("HealingBlast").Type,
                        Projectile.damage * 2,
                        0.5f,
                        Projectile.owner
                    );
                    Main.projectile[j].scale = 0.8f;
                    int k = Projectile.NewProjectile(
                        source,
                        new Vector2(Projectile.position.X - 70, Projectile.position.Y),
                        Vector2.Zero,  
                        Mod.Find<ModProjectile>("HealingBlast").Type,
                        Projectile.damage * 2,
                        0.5f,
                        Projectile.owner
                    );
                    Main.projectile[k].scale = 0.8f;
                    int l = Projectile.NewProjectile(
                        source,
                        new Vector2(Projectile.position.X, Projectile.position.Y + 70),
                        Vector2.Zero,  
                        Mod.Find<ModProjectile>("HealingBlast").Type,
                        Projectile.damage * 2,
                        0.5f,
                        Projectile.owner
                    );
                    Main.projectile[l].scale = 0.8f;
                    int m = Projectile.NewProjectile(
                        source,
                        new Vector2(Projectile.position.X, Projectile.position.Y - 70),
                        Vector2.Zero,  
                        Mod.Find<ModProjectile>("HealingBlast").Type,
                        Projectile.damage * 2,
                        0.5f,
                        Projectile.owner
                    );
                    Main.projectile[m].scale = 0.8f;
                }
                if (player.HasBuff(Mod.Find<ModBuff>("RoundBlastBuff").Type) && !modPlayer.nitro)
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 60, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("HealingBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 60, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("HealingBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y + 60), Vector2.Zero, Mod.Find<ModProjectile>("HealingBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y - 60), Vector2.Zero, Mod.Find<ModProjectile>("HealingBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 40, Projectile.position.Y + 40), Vector2.Zero, Mod.Find<ModProjectile>("HealingBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 40, Projectile.position.Y + 40), Vector2.Zero, Mod.Find<ModProjectile>("HealingBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 40, Projectile.position.Y - 40), Vector2.Zero, Mod.Find<ModProjectile>("HealingBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int h = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 40, Projectile.position.Y - 40), Vector2.Zero, Mod.Find<ModProjectile>("HealingBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("SquareBlastBuff").Type) && !modPlayer.nitro)
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 70, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("HealingBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 70, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("HealingBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y + 70), Vector2.Zero, Mod.Find<ModProjectile>("HealingBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y - 70), Vector2.Zero, Mod.Find<ModProjectile>("HealingBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 70, Projectile.position.Y + 70), Vector2.Zero, Mod.Find<ModProjectile>("HealingBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 70, Projectile.position.Y + 70), Vector2.Zero, Mod.Find<ModProjectile>("HealingBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 70, Projectile.position.Y - 70), Vector2.Zero, Mod.Find<ModProjectile>("HealingBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int h = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 70, Projectile.position.Y - 70), Vector2.Zero, Mod.Find<ModProjectile>("HealingBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("NitroBuff").Type) && !modPlayer.pyro)
                {
                    SoundEngine.PlaySound(SoundID.Item100, Projectile.position);
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("HealingBurst").Type, Projectile.damage, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("ReinforcedBurstBuff").Type) && !modPlayer.pyro)
                {
                    SoundEngine.PlaySound(SoundID.Item100, Projectile.position);
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("HealingBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 50, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("HealingBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 50, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("HealingBurst").Type, Projectile.damage, 1f, Projectile.owner);
                }

                if (player.HasBuff(Mod.Find<ModBuff>("LinearBurstBuff").Type) && !modPlayer.pyro)
                {
                    SoundEngine.PlaySound(SoundID.Item100, Projectile.position);
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("HealingBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 50, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("HealingBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 50, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("HealingBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 100, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("HealingBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 100, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("HealingBurst").Type, Projectile.damage, 1f, Projectile.owner);
                }

                if (player.HasBuff(Mod.Find<ModBuff>("NitroBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("PyroBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item42, Projectile.position);
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("HealingBlast").Type, Projectile.damage * 2, 1.5f, Projectile.owner);
                    Main.projectile[a].scale = 1.5f;
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 20, Projectile.position.Y), new Vector2(5, 0), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 20, Projectile.position.Y), new Vector2(-5, 0), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("ReinforcedBurstBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("PyroBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item42, Projectile.position);
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("HealingBlast").Type, Projectile.damage * 2, 1.5f, Projectile.owner);
                    Main.projectile[a].scale = 1.5f;
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 10, Projectile.position.Y - 10), new Vector2(6, 0), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 10, Projectile.position.Y - 10), new Vector2(-6, 0), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 40, Projectile.position.Y + 10), new Vector2(4, 0), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 40, Projectile.position.Y + 10), new Vector2(-4, 0), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("LinearBurstBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("PyroBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item42, Projectile.position);
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("HealingBlast").Type, Projectile.damage * 2, 1.5f, Projectile.owner);
                    Main.projectile[a].scale = 1.5f;
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 10, Projectile.position.Y - 15), new Vector2(6, 0), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 10, Projectile.position.Y - 15), new Vector2(-6, 0), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 40, Projectile.position.Y), new Vector2(5, 0), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 40, Projectile.position.Y), new Vector2(-5, 0), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 70, Projectile.position.Y + 15), new Vector2(4, 0), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage, 1f, Projectile.owner);
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 70, Projectile.position.Y + 15), new Vector2(-4, 0), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("RoundBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("NitroBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    int z = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("HealingBlast").Type, Projectile.damage * 2, 1.5f, Projectile.owner);
                    Main.projectile[z].scale = 1.25f;
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 25, Projectile.position.Y), new Vector2(4, 0), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 25, Projectile.position.Y), new Vector2(-4, 0), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y + 25), new Vector2(0, 4), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y - 25), new Vector2(0, -4), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 20, Projectile.position.Y + 20), new Vector2(4, 4), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[e].scale = 0.8f;
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 20, Projectile.position.Y + 20), new Vector2(-4, 4), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[f].scale = 0.8f;
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 20, Projectile.position.Y - 20), new Vector2(4, -4), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[g].scale = 0.8f;
                    int h = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 20, Projectile.position.Y - 20), new Vector2(-4, -4), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[h].scale = 0.8f;
                }
                if (player.HasBuff(Mod.Find<ModBuff>("RoundBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("ReinforcedBurstBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    int z = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), Vector2.Zero, Mod.Find<ModProjectile>("HealingBlast").Type, Projectile.damage * 2, 1.5f, Projectile.owner);
                    Main.projectile[z].scale = 1.25f;
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 65, Projectile.position.Y), new Vector2(3, 0), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 65, Projectile.position.Y), new Vector2(-3, 0), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y + 35), new Vector2(0, 4), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y - 35), new Vector2(0, -4), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 50, Projectile.position.Y + 20), new Vector2(0, 4), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[e].scale = 1.2f;
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 50, Projectile.position.Y + 20), new Vector2(0, 4), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[f].scale = 1.2f;
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 50, Projectile.position.Y - 20), new Vector2(0, -4), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[g].scale = 1.2f;
                    int h = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 50, Projectile.position.Y - 20), new Vector2(0, -4), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[h].scale = 1.2f;
                }
                if (player.HasBuff(Mod.Find<ModBuff>("RoundBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("LinearBurstBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);               
                    int z = Projectile.NewProjectile(source, Projectile.position, Vector2.Zero, Mod.Find<ModProjectile>("HealingBlast").Type, Projectile.damage * 2, 1.5f, Projectile.owner);
                    Main.projectile[z].scale = 1.25f;
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 65, Projectile.position.Y), new Vector2(3, 0), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 65, Projectile.position.Y), new Vector2(-3, 0), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y + 35), new Vector2(0, 4), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y - 35), new Vector2(0, -4), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 50, Projectile.position.Y + 20), new Vector2(0, 4), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[e].scale = 0.8f;
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 50, Projectile.position.Y + 20), new Vector2(0, 4), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[f].scale = 0.8f;
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 50, Projectile.position.Y - 20), new Vector2(0, -4), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[g].scale = 0.8f;
                    int h = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 50, Projectile.position.Y - 20), new Vector2(0, -4), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[h].scale = 0.8f;
                    int i = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 80, Projectile.position.Y + 20), new Vector2(0, 4), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[i].scale = 0.6f;
                    int k = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 80, Projectile.position.Y + 20), new Vector2(0, 4), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[k].scale = 0.6f;
                    int l = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 80, Projectile.position.Y - 20), new Vector2(0, -4), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[l].scale = 0.6f;
                    int m = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 80, Projectile.position.Y - 20), new Vector2(0, -4), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[m].scale = 0.6f;
                }
                if (player.HasBuff(Mod.Find<ModBuff>("SquareBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("NitroBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    int d = Projectile.NewProjectile(source, Projectile.position, Vector2.Zero, Mod.Find<ModProjectile>("HealingBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[d].scale = 1.5f;
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y + 30), new Vector2(3, 3), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y + 30), new Vector2(-3, 3), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y - 30), new Vector2(3, -3), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    int h = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y - 30), new Vector2(-3, -3), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("SquareBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("ReinforcedBurstBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    int d = Projectile.NewProjectile(source, Projectile.position, Vector2.Zero, Mod.Find<ModProjectile>("HealingBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[d].scale = 1.5f;
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y + 30), new Vector2(2, 3), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[e].scale = 0.75f;
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y + 30), new Vector2(-2, 3), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[f].scale = 0.75f;
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y - 30), new Vector2(2, -3), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[g].scale = 0.75f;
                    int h = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y - 30), new Vector2(-2, -3), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[h].scale = 0.75f;
                    int i = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y + 30), new Vector2(3, 2), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[i].scale = 0.75f;
                    int j = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y + 30), new Vector2(-3, 2), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[j].scale = 0.75f;
                    int k = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y - 30), new Vector2(3, -2), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[k].scale = 0.75f;
                    int l = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y - 30), new Vector2(-3, -2), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[l].scale = 0.75f;
                }
                if (player.HasBuff(Mod.Find<ModBuff>("SquareBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("LinearBurstBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);                
                    int d = Projectile.NewProjectile(source, Projectile.position, Vector2.Zero, Mod.Find<ModProjectile>("HealingBlast").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[d].scale = 1.5f;
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y + 30), new Vector2(2, 4), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[e].scale = 0.65f;
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y + 30), new Vector2(-2, 4), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[f].scale = 0.65f;
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y - 30), new Vector2(2, -4), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[g].scale = 0.65f;
                    int h = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y - 30), new Vector2(-2, -4), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[h].scale = 0.65f;
                    int i = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y + 30), new Vector2(4, 2), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[i].scale = 0.65f;
                    int j = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y + 30), new Vector2(-4, 2), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[j].scale = 0.65f;
                    int k = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y - 30), new Vector2(4, -2), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[k].scale = 0.65f;
                    int l = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y - 30), new Vector2(-4, -2), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[l].scale = 0.65f;
                    int m = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y + 30), new Vector2(3, 3), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[m].scale = 0.7f;
                    int n = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y + 30), new Vector2(-3, 3), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[n].scale = 0.7f;
                    int o = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y - 30), new Vector2(3, -3), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[o].scale = 0.7f;
                    int p = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y - 30), new Vector2(-3, -3), Mod.Find<ModProjectile>("HealingSkull").Type, Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[p].scale = 0.7f;
                }
                if (player.HasBuff(Mod.Find<ModBuff>("NitroBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("ChemikazeBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item100, Projectile.position);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y), new Vector2(-2, 0), Mod.Find<ModProjectile>("HealingBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y), new Vector2(2, 0), Mod.Find<ModProjectile>("HealingBurst").Type, Projectile.damage, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("ReinforcedBurstBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("ChemikazeBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item100, Projectile.position);                  
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 40, Projectile.position.Y), new Vector2(-2, 0), Mod.Find<ModProjectile>("HealingBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 40, Projectile.position.Y), new Vector2(2, 0), Mod.Find<ModProjectile>("HealingBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 60, Projectile.position.Y), new Vector2(-3, 0), Mod.Find<ModProjectile>("HealingBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 60, Projectile.position.Y), new Vector2(3, 0), Mod.Find<ModProjectile>("HealingBurst").Type, Projectile.damage, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("LinearBurstBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("ChemikazeBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item100, Projectile.position);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 40, Projectile.position.Y), new Vector2(-2, 0), Mod.Find<ModProjectile>("HealingBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 40, Projectile.position.Y), new Vector2(2, 0), Mod.Find<ModProjectile>("HealingBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 60, Projectile.position.Y), new Vector2(-3, 0), Mod.Find<ModProjectile>("HealingBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 60, Projectile.position.Y), new Vector2(3, 0), Mod.Find<ModProjectile>("HealingBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 80, Projectile.position.Y), new Vector2(-4, 0), Mod.Find<ModProjectile>("HealingBurst").Type, Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 80, Projectile.position.Y), new Vector2(4, 0), Mod.Find<ModProjectile>("HealingBurst").Type, Projectile.damage, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("CrossBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("NitroBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);             
                    int a = Projectile.NewProjectile(source, Projectile.position, new Vector2(4, 0), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, Projectile.position, new Vector2(-4, 0), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 4), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, Projectile.position, new Vector2(0, -4), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 60, Projectile.position.Y), new Vector2(-4, 0), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 60, Projectile.position.Y), new Vector2(4, 0), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y + 60), new Vector2(0, -4), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int h = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y - 60), new Vector2(0, 4), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("CrossBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("ReinforcedBurstBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    int a = Projectile.NewProjectile(source, Projectile.position, new Vector2(6, 0), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, Projectile.position, new Vector2(-6, 0), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 6), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, Projectile.position, new Vector2(0, -6), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 60, Projectile.position.Y), new Vector2(-6, 0), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 60, Projectile.position.Y), new Vector2(6, 0), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y + 60), new Vector2(0, -6), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int h = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y - 60), new Vector2(0, 6), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                }
                if (player.HasBuff(Mod.Find<ModBuff>("CrossBlastBuff").Type) && player.HasBuff(Mod.Find<ModBuff>("LinearBurstBuff").Type))
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    int a = Projectile.NewProjectile(source, Projectile.position, new Vector2(8, 0), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, Projectile.position, new Vector2(-8, 0), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 8), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, Projectile.position, new Vector2(0, -8), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 60, Projectile.position.Y), new Vector2(-8, 0), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 60, Projectile.position.Y), new Vector2(8, 0), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y + 60), new Vector2(0, -8), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                    int h = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y - 60), new Vector2(0, 8), Mod.Find<ModProjectile>("HealingSkullburst").Type, Projectile.damage * 1, 1f, Projectile.owner);
                }
            }
        }

	}
}