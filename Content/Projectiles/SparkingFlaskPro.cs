using System;
using Terraria.Audio;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
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
	public class SparkingFlaskPro : ModProjectile
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
			Projectile.penetrate = 1;
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
							Projectile.NewProjectile(Projectile.GetSource_FromThis(), value10.X, value10.Y, num438, num439, ModContent.ProjectileType<TheCadenceProj>(), Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0f);
						}
					}
				}
			}
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

            if (player.HasBuff(ModContent.BuffType<BrassChipBuff>()))
			{
				for (int i = 0; i < 5; i++)
				{
					Vector2 vector2 = new Vector2(player.position.X + 75f * (float)Math.Cos(12), player.position.Y + 1075f * (float)Math.Sin(12));
					Vector2 Velocity = Helper.VelocityToPoint(vector2, Helper.RandomPointInArea(new Vector2(Projectile.Center.X - 10, Projectile.Center.Y - 10), new Vector2(Projectile.Center.X + 20, Projectile.Center.Y + 20)), 24);
					int a = Projectile.NewProjectile(Projectile.GetSource_FromThis(), vector2.X, vector2.Y, Velocity.X, Velocity.Y, 134, Projectile.damage, 1f);
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
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, value17.X, value17.Y, ModContent.ProjectileType<Shatter1>(), Projectile.damage, 1f, Projectile.owner, 0f, Main.rand.Next(-45, 1));
				}
			}

			if (!modPlayer.pyro && !modPlayer.nitro)
			{
				if (Projectile.owner == Main.myPlayer)
				{
					int num220 = Main.rand.Next(2, 3);
					for (int num221 = 0; num221 < num220; num221++)
					{
						Vector2 value17 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-101, 0));
						value17.Normalize();
						value17 *= Main.rand.Next(10, 201) * 0.01f;
						Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, value17.X, value17.Y, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage, 1f, Projectile.owner, 0f, Main.rand.Next(-45, 1));
					}
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FierySkull>(), Projectile.damage, 1f, Projectile.owner, 0f, Main.rand.Next(-45, 1));
				}

			}
			if (Projectile.owner == Main.myPlayer)
			{
				if (player.HasBuff(ModContent.BuffType<DesertEmperorSetBuff>()))
				{
					int a = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FlaskWasp>(), Projectile.damage * 2, 1.5f, Projectile.owner);
					int b = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FlaskWasp>(), Projectile.damage * 2, 1.5f, Projectile.owner);
				}
				if (player.HasBuff(ModContent.BuffType<PyroBuff>()) && !modPlayer.nitro)
				{
					SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
					int a = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1.5f, Projectile.owner);
					Main.projectile[a].scale = 1.5f;
				}
				if (player.HasBuff(ModContent.BuffType<ChemikazeBuff>()) && !modPlayer.nitro)
				{
					SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
					int a = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1.25f, Projectile.owner);
					Main.projectile[a].scale = 1.25f;
					int b = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 32, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
					int c = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 32, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
					int d = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y + 32, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
					int e = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y - 32, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
				}
				if (player.HasBuff(ModContent.BuffType<CrossBlastBuff>()) && !modPlayer.nitro)
				{
					SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
					int a = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1.25f, Projectile.owner);
					Main.projectile[a].scale = 1.25f;
					int b = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 30, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
					int c = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 30, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
					int d = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y + 30, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
					int e = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y - 30, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
					int f = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 50, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 0.7f, Projectile.owner);
					Main.projectile[f].scale = 0.7f;
					int g = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 50, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 0.7f, Projectile.owner);
					Main.projectile[g].scale = 0.7f;
					int h = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y + 50, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 0.7f, Projectile.owner);
					Main.projectile[h].scale = 0.7f;
					int i = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y - 50, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 0.7f, Projectile.owner);
					Main.projectile[i].scale = 0.7f;
					int j = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 70, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 0.5f, Projectile.owner);
					Main.projectile[j].scale = 0.8f;
					int k = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 70, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 0.5f, Projectile.owner);
					Main.projectile[k].scale = 0.8f;
					int l = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y + 70, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 0.5f, Projectile.owner);
					Main.projectile[l].scale = 0.8f;
					int m = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y - 70, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 0.5f, Projectile.owner);
					Main.projectile[m].scale = 0.8f;
				}
				if (player.HasBuff(ModContent.BuffType<RoundBlastBuff>()) && !modPlayer.nitro)
				{
					SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
					int a = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 60, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
					int b = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 60, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
					int c = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y + 60, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
					int d = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y - 60, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
					int e = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 40, Projectile.position.Y + 40, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
					int f = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 40, Projectile.position.Y + 40, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
					int g = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 40, Projectile.position.Y - 40, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
					int h = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 40, Projectile.position.Y - 40, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
				}

				if (player.HasBuff(ModContent.BuffType<SquareBlastBuff>()) && !modPlayer.nitro)
				{
					SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
					int a = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 70, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
					int b = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 70, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
					int c = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y + 70, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
					int d = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y - 70, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
					int e = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 70, Projectile.position.Y + 70, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
					int f = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 70, Projectile.position.Y + 70, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
					int g = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 70, Projectile.position.Y - 70, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
					int h = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 70, Projectile.position.Y - 70, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
				}

				if (player.HasBuff(ModContent.BuffType<NitroBuff>()) && !modPlayer.pyro)
				{
					SoundEngine.PlaySound(SoundID.Item100, Projectile.position);
					int a = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBurst>(), Projectile.damage, 1f, Projectile.owner);
				}

				if (player.HasBuff(ModContent.BuffType<ReinforcedBurstBuff>()) && !modPlayer.pyro)
				{
					SoundEngine.PlaySound(SoundID.Item100, Projectile.position);
					int a = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBurst>(), Projectile.damage, 1f, Projectile.owner);
					int b = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 50, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBurst>(), Projectile.damage, 1f, Projectile.owner);
					int c = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 50, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBurst>(), Projectile.damage, 1f, Projectile.owner);
				}

				if (player.HasBuff(ModContent.BuffType<LinearBurstBuff>()) && !modPlayer.pyro)
				{
					SoundEngine.PlaySound(SoundID.Item100, Projectile.position);
					int a = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBurst>(), Projectile.damage, 1f, Projectile.owner);
					int b = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 50, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBurst>(), Projectile.damage, 1f, Projectile.owner);
					int c = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 50, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBurst>(), Projectile.damage, 1f, Projectile.owner);
					int d = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 100, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBurst>(), Projectile.damage, 1f, Projectile.owner);
					int e = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 100, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBurst>(), Projectile.damage, 1f, Projectile.owner);
				}

				if (player.HasBuff(ModContent.BuffType<NitroBuff>()) && player.HasBuff(ModContent.BuffType<PyroBuff>()))
				{
					SoundEngine.PlaySound(SoundID.Item42, Projectile.position);
					int a = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1.5f, Projectile.owner);
					Main.projectile[a].scale = 1.5f;
					int b = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 20, Projectile.position.Y, +5, 0, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage, 1f, Projectile.owner);
					int c = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 20, Projectile.position.Y, -5, 0, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage, 1f, Projectile.owner);
				}

				if (player.HasBuff(ModContent.BuffType<ReinforcedBurstBuff>()) && player.HasBuff(ModContent.BuffType<PyroBuff>()))
				{
					SoundEngine.PlaySound(SoundID.Item42, Projectile.position);
					int a = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1.5f, Projectile.owner);
					Main.projectile[a].scale = 1.5f;
					int b = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 10, Projectile.position.Y - 10, +6, 0, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage, 1f, Projectile.owner);
					int c = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 10, Projectile.position.Y - 10, -6, 0, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage, 1f, Projectile.owner);
					int d = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 40, Projectile.position.Y + 10, +4, 0, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage, 1f, Projectile.owner);
					int e = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 40, Projectile.position.Y + 10, -4, 0, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage, 1f, Projectile.owner);
				}

				if (player.HasBuff(ModContent.BuffType<LinearBurstBuff>()) && player.HasBuff(ModContent.BuffType<PyroBuff>()))
				{
					SoundEngine.PlaySound(SoundID.Item42, Projectile.position);
					int a = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1.5f, Projectile.owner);
					Main.projectile[a].scale = 1.5f;
					int b = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 10, Projectile.position.Y - 15, +6, 0, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage, 1f, Projectile.owner);
					int c = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 10, Projectile.position.Y - 15, -6, 0, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage, 1f, Projectile.owner);
					int d = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 40, Projectile.position.Y, +5, 0, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage, 1f, Projectile.owner);
					int e = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 40, Projectile.position.Y, -5, 0, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage, 1f, Projectile.owner);
					int f = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 70, Projectile.position.Y + 15, +4, 0, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage, 1f, Projectile.owner);
					int g = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 70, Projectile.position.Y + 15, -4, 0, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage, 1f, Projectile.owner);
				}

				if (player.HasBuff(ModContent.BuffType<RoundBlastBuff>()) && player.HasBuff(ModContent.BuffType<NitroBuff>()))
				{
					SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
					int z = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1.5f, Projectile.owner);
					Main.projectile[z].scale = 1.25f;
					int a = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 25, Projectile.position.Y, 4, 0, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					int b = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 25, Projectile.position.Y, -4, 0, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					int c = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y + 25, 0, 4, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					int d = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y - 25, 0, -4, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					int e = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 20, Projectile.position.Y + 20, 4, 4, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[e].scale = 0.8f;
					int f = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 20, Projectile.position.Y + 20, -4, 4, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[f].scale = 0.8f;
					int g = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 20, Projectile.position.Y - 20, 4, -4, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[g].scale = 0.8f;
					int h = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 20, Projectile.position.Y - 20, -4, -4, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[h].scale = 0.8f;
				}

				if (player.HasBuff(ModContent.BuffType<RoundBlastBuff>()) && player.HasBuff(ModContent.BuffType<ReinforcedBurstBuff>()))
				{
					SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
					int z = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1.5f, Projectile.owner);
					Main.projectile[z].scale = 1.25f;
					int a = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 65, Projectile.position.Y, 3, 0, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					int b = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 65, Projectile.position.Y, -3, 0, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					int c = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y + 35, 0, 4, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					int d = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y - 35, 0, -4, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					int e = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 50, Projectile.position.Y + 20, 0, 4, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[e].scale = 1.2f;
					int f = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 50, Projectile.position.Y + 20, 0, 4, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[f].scale = 1.2f;
					int g = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 50, Projectile.position.Y - 20, 0, -4, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[g].scale = 1.2f;
					int h = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 50, Projectile.position.Y - 20, 0, -4, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[h].scale = 1.2f;
				}

				if (player.HasBuff(ModContent.BuffType<RoundBlastBuff>()) && player.HasBuff(ModContent.BuffType<LinearBurstBuff>()))
				{
					SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
					int z = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1.5f, Projectile.owner);
					Main.projectile[z].scale = 1.25f;
					int a = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 65, Projectile.position.Y, 3, 0, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					int b = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 65, Projectile.position.Y, -3, 0, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					int c = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y + 35, 0, 4, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					int d = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y - 35, 0, -4, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					int e = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 50, Projectile.position.Y + 20, 0, 4, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[e].scale = 0.8f;
					int f = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 50, Projectile.position.Y + 20, 0, 4, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[f].scale = 0.8f;
					int g = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 50, Projectile.position.Y - 20, 0, -4, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[g].scale = 0.8f;
					int h = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 50, Projectile.position.Y - 20, 0, -4, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[h].scale = 0.8f;
					int i = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 80, Projectile.position.Y + 20, 0, 4, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[i].scale = 0.6f;
					int k = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 80, Projectile.position.Y + 20, 0, 4, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[k].scale = 0.6f;
					int l = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 80, Projectile.position.Y - 20, 0, -4, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[l].scale = 0.6f;
					int m = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 80, Projectile.position.Y - 20, 0, -4, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[m].scale = 0.6f;
				}

				if (player.HasBuff(ModContent.BuffType<SquareBlastBuff>()) && player.HasBuff(ModContent.BuffType<NitroBuff>()))
				{
					SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
					int d = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[d].scale = 1.5f;
					int e = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 30, Projectile.position.Y + 30, 3, 3, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage * 2, 1f, Projectile.owner);
					int f = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 30, Projectile.position.Y + 30, -3, 3, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage * 2, 1f, Projectile.owner);
					int g = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 30, Projectile.position.Y - 30, 3, -3, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage * 2, 1f, Projectile.owner);
					int h = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 30, Projectile.position.Y - 30, -3, -3, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage * 2, 1f, Projectile.owner);
				}

				if (player.HasBuff(ModContent.BuffType<SquareBlastBuff>()) && player.HasBuff(ModContent.BuffType<ReinforcedBurstBuff>()))
				{
					SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
					int d = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[d].scale = 1.5f;
					int e = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 30, Projectile.position.Y + 30, 2, 3, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[e].scale = 0.75f;
					int f = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 30, Projectile.position.Y + 30, -2, 3, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[f].scale = 0.75f;
					int g = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 30, Projectile.position.Y - 30, 2, -3, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[g].scale = 0.75f;
					int h = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 30, Projectile.position.Y - 30, -2, -3, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[h].scale = 0.75f;
					int i = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 30, Projectile.position.Y + 30, 3, 2, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[i].scale = 0.75f;
					int j = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 30, Projectile.position.Y + 30, -3, 2, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[j].scale = 0.75f;
					int k = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 30, Projectile.position.Y - 30, 3, -2, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[k].scale = 0.75f;
					int l = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 30, Projectile.position.Y - 30, -3, -2, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[l].scale = 0.75f;
				}

				if (player.HasBuff(ModContent.BuffType<SquareBlastBuff>()) && player.HasBuff(ModContent.BuffType<LinearBurstBuff>()))
				{
					SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
					int d = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<FieryBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[d].scale = 1.5f;
					int e = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 30, Projectile.position.Y + 30, 2, 4, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[e].scale = 0.65f;
					int f = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 30, Projectile.position.Y + 30, -2, 4, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[f].scale = 0.65f;
					int g = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 30, Projectile.position.Y - 30, 2, -4, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[g].scale = 0.65f;
					int h = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 30, Projectile.position.Y - 30, -2, -4, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[h].scale = 0.65f;
					int i = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 30, Projectile.position.Y + 30, 4, 2, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[i].scale = 0.65f;
					int j = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 30, Projectile.position.Y + 30, -4, 2, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[j].scale = 0.65f;
					int k = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 30, Projectile.position.Y - 30, 4, -2, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[k].scale = 0.65f;
					int l = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 30, Projectile.position.Y - 30, -4, -2, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[l].scale = 0.65f;
					int m = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 30, Projectile.position.Y + 30, 3, 3, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[m].scale = 0.7f;
					int n = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 30, Projectile.position.Y + 30, -3, 3, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[n].scale = 0.7f;
					int o = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 30, Projectile.position.Y - 30, 3, -3, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[o].scale = 0.7f;
					int p = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 30, Projectile.position.Y - 30, -3, -3, ModContent.ProjectileType<SparkingBallz>(), Projectile.damage * 2, 1f, Projectile.owner);
					Main.projectile[p].scale = 0.7f;
				}

				if (player.HasBuff(ModContent.BuffType<NitroBuff>()) && player.HasBuff(ModContent.BuffType<ChemikazeBuff>()))
				{
					SoundEngine.PlaySound(SoundID.Item100, Projectile.position);
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 30, Projectile.position.Y, -2, 0, ModContent.ProjectileType<FieryBurst>(), Projectile.damage, 1f, Projectile.owner);
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 30, Projectile.position.Y, +2, 0, ModContent.ProjectileType<FieryBurst>(), Projectile.damage, 1f, Projectile.owner);
				}

				if (player.HasBuff(ModContent.BuffType<ReinforcedBurstBuff>()) && player.HasBuff(ModContent.BuffType<ChemikazeBuff>()))
				{
					SoundEngine.PlaySound(SoundID.Item100, Projectile.position);
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 40, Projectile.position.Y, -2, 0, ModContent.ProjectileType<FieryBurst>(), Projectile.damage, 1f, Projectile.owner);
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 40, Projectile.position.Y, +2, 0, ModContent.ProjectileType<FieryBurst>(), Projectile.damage, 1f, Projectile.owner);
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 60, Projectile.position.Y, -3, 0, ModContent.ProjectileType<FieryBurst>(), Projectile.damage, 1f, Projectile.owner);
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 60, Projectile.position.Y, +3, 0, ModContent.ProjectileType<FieryBurst>(), Projectile.damage, 1f, Projectile.owner);
				}

				if (player.HasBuff(ModContent.BuffType<LinearBurstBuff>()) && player.HasBuff(ModContent.BuffType<ChemikazeBuff>()))
				{
					SoundEngine.PlaySound(SoundID.Item100, Projectile.position);
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 40, Projectile.position.Y, -2, 0, ModContent.ProjectileType<FieryBurst>(), Projectile.damage, 1f, Projectile.owner);
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 40, Projectile.position.Y, +2, 0, ModContent.ProjectileType<FieryBurst>(), Projectile.damage, 1f, Projectile.owner);
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 60, Projectile.position.Y, -3, 0, ModContent.ProjectileType<FieryBurst>(), Projectile.damage, 1f, Projectile.owner);
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 60, Projectile.position.Y, +3, 0, ModContent.ProjectileType<FieryBurst>(), Projectile.damage, 1f, Projectile.owner);
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 80, Projectile.position.Y, -4, 0, ModContent.ProjectileType<FieryBurst>(), Projectile.damage, 1f, Projectile.owner);
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 80, Projectile.position.Y, +4, 0, ModContent.ProjectileType<FieryBurst>(), Projectile.damage, 1f, Projectile.owner);
				}

				if (player.HasBuff(ModContent.BuffType<CrossBlastBuff>()) && player.HasBuff(ModContent.BuffType<NitroBuff>()))
				{
					SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
					int a = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 4, 0, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 1, 1f, Projectile.owner);
					int b = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, -4, 0, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 1, 1f, Projectile.owner);
					int c = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 4, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 1, 1f, Projectile.owner);
					int d = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, -4, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 1, 1f, Projectile.owner);
					int e = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 60, Projectile.position.Y, -4, 0, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 1, 1f, Projectile.owner);
					int f = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 60, Projectile.position.Y, 4, 0, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 1, 1f, Projectile.owner);
					int g = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y + 60, 0, -4, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 1, 1f, Projectile.owner);
					int h = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y - 60, 0, 4, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 1, 1f, Projectile.owner);
				}

				if (player.HasBuff(ModContent.BuffType<CrossBlastBuff>()) && player.HasBuff(ModContent.BuffType<ReinforcedBurstBuff>()))
				{
					SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
					int a = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 6, 0, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 1, 1f, Projectile.owner);
					int b = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, -6, 0, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 1, 1f, Projectile.owner);
					int c = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 6, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 1, 1f, Projectile.owner);
					int d = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, -6, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 1, 1f, Projectile.owner);
					int e = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 60, Projectile.position.Y, -6, 0, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 1, 1f, Projectile.owner);
					int f = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 60, Projectile.position.Y, 6, 0, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 1, 1f, Projectile.owner);
					int g = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y + 60, 0, -6, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 1, 1f, Projectile.owner);
					int h = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y - 60, 0, 6, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 1, 1f, Projectile.owner);
				}

				if (player.HasBuff(ModContent.BuffType<CrossBlastBuff>()) && player.HasBuff(ModContent.BuffType<LinearBurstBuff>()))
				{
					SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
					int a = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 8, 0, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 1, 1f, Projectile.owner);
					int b = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, -8, 0, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 1, 1f, Projectile.owner);
					int c = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 8, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 1, 1f, Projectile.owner);
					int d = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, -8, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 1, 1f, Projectile.owner);
					int e = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + 60, Projectile.position.Y, -8, 0, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 1, 1f, Projectile.owner);
					int f = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X - 60, Projectile.position.Y, 8, 0, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 1, 1f, Projectile.owner);
					int g = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y + 60, 0, -8, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 1, 1f, Projectile.owner);
					int h = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y - 60, 0, 8, ModContent.ProjectileType<FierySkullburst>(), Projectile.damage * 1, 1f, Projectile.owner);
				}
			}
		}

	}
}