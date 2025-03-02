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
	public class DukeFlaskPro : ModProjectile
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
			Projectile.penetrate = 1;
			Projectile.timeLeft = 1200;
			Projectile.scale = 1f;
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
					SoundEngine.PlaySound(SoundID.Item10);
				}
			}
			else
			{
				Projectile.Kill();
			}

			return false;
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			Projectile.Kill();
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
			if (Projectile.owner == Main.myPlayer)
			{
				int num231 = (int)(Projectile.Center.Y / 16f);
				int num232 = (int)(Projectile.Center.X / 16f);
				int num233 = 100;
				if (num232 < 10)
				{
					num232 = 10;
				}
				if (num232 > Main.maxTilesX - 10)
				{
					num232 = Main.maxTilesX - 10;
				}
				if (num231 < 10)
				{
					num231 = 10;
				}
				if (num231 > Main.maxTilesY - num233 - 10)
				{
					num231 = Main.maxTilesY - num233 - 10;
				}
				for (int num234 = num231; num234 < num231 + num233; num234++)
				{
					Tile tile = Main.tile[num232, num234];
					if (tile.HasTile && (Main.tileSolid[tile.TileType] || tile.LiquidAmount != 0))
					{
						num231 = num234;
						break;
					}
				}
				int num236 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), num232 * 16 + 8, num231 * 16 - 24, 0f, 0f, ModContent.ProjectileType<Dukado>(), 80, 4f, Main.myPlayer, 16f, 15f);
				int num237 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0f, 0f, ModContent.ProjectileType<Dukado>(), 80, 4f, Main.myPlayer, 16f, 15f);
				Main.projectile[num236].netUpdate = true;
				Main.projectile[num237].netUpdate = true;
			}
		}
	}
}