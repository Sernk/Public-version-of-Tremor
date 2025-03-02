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
using TremorMod.Utilities;
using Filters = Terraria.Graphics.Effects.Filters;
using TremorMod.Content.Buffs;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.NPCs.Bosses.NovaPillar.Projectiles
{
	public class NovaFlask_Proj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 18;
			Projectile.height = 28;
			Projectile.friendly = true;
			Projectile.aiStyle = 2;
			Projectile.timeLeft = 1200;
			//Projectile.penetrate = Main.LocalPlayer.HasBuff(ModContent.BuffType<BouncingCasingBuff>()) ? 3 : 1;
		}

        public override void OnSpawn(IEntitySource source)
        {
            Player player = Main.player[Projectile.owner];

            if (player.HasBuff(ModContent.BuffType<BouncingCasingBuff>()))
            {
                Projectile.penetrate = 3;
            }
        }

        public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
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
                            Projectile.NewProjectile(Projectile.GetSource_FromThis(), value10, new Vector2(num438, num439), ModContent.ProjectileType<TheCadenceProj>(), Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0f);
                        }
                    }
                }
            }
        }


        public static Vector2 RandomPointInArea(Vector2 min, Vector2 max)
        {
            float x = Main.rand.NextFloat(min.X, max.X);
            float y = Main.rand.NextFloat(min.Y, max.Y);
            return new Vector2(x, y);
        }

        public override void OnKill(int timeLeft)
        {
            Player player = Main.player[Projectile.owner];

            // Исправлено получение ModPlayer
            MPlayer modPlayer = player.GetModPlayer<MPlayer>();

            // Звук разрушения
            SoundEngine.PlaySound(SoundID.Item107, Projectile.position);

            // Генерация Gore
            Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.position, -Projectile.oldVelocity * 0.2f, 704, 1f);
            Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.position, -Projectile.oldVelocity * 0.2f, 705, 1f);
            Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.position, -Projectile.oldVelocity * 0.2f, 705, 1f);

            if (Projectile.owner == Main.myPlayer)
            {
                int num220 = Main.rand.Next(2, 3);
                for (int num221 = 0; num221 < num220; num221++)
                {
                    Vector2 value17 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                    value17.Normalize();
                    value17 *= Main.rand.Next(10, 201) * 0.01f;
                    int k = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, value17, ModContent.ProjectileType<NovaFlask_ProjBall>(), Projectile.damage, 1f, Projectile.owner, 0f, Main.rand.Next(-45, 1));
                    Main.projectile[k].friendly = true;
                }
            }

            // Проверка наличия баффа и создание новых снарядов
            if (player.HasBuff(ModContent.BuffType<BrassChipBuff>()))
            {
                for (int i = 0; i < 5; i++)
                {
                    Vector2 vector2 = new Vector2(player.position.X + 75f * (float)Math.Cos(12), player.position.Y + 1075f * (float)Math.Sin(12));

                    // Заменён вызов RandomPointInArea
                    Vector2 target = RandomPointInArea(new Vector2(Projectile.Center.X - 10, Projectile.Center.Y - 10), new Vector2(Projectile.Center.X + 20, Projectile.Center.Y + 20));
                    Vector2 velocity = Helper.VelocityToPoint(vector2, target, 24);

                    int a = Projectile.NewProjectile(Projectile.GetSource_FromThis(), vector2, velocity, 134, Projectile.damage, 1f);
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
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, value17, ModContent.ProjectileType<Shatter1>(), Projectile.damage, 1f, Projectile.owner, 0f, Main.rand.Next(-45, 1));
                }
            }
        }


        public override bool PreDraw(ref Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                Main.spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }

    }
}