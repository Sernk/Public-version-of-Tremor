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
using TremorMod.Utilities;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Filters = Terraria.Graphics.Effects.Filters;
using TremorMod.Content.Buffs;
using TremorMod;

namespace TremorMod.Content.NPCs.Bosses.NovaPillar.Projectiles
{
	public class NovaFlask_ProjBall : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.SpikyBall);
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.timeLeft = 180;
			Projectile.width = 20;
			Main.projFrames[Projectile.type] = 3;
			Projectile.height = 20;
			/*if (Main.LocalPlayer.HasBuff(ModContent.BuffType<BouncingCasingBuff>()))
			{
				Projectile.scale = 3f;
			}
			else
				Projectile.scale = 1f;*/
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void AI()
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
			for (int i = 0; i < Main.dust.Length; i++)
			{
				if ((Main.dust[i].type == DustID.Torch || Main.dust[i].type == 31 || Main.dust[i].type == 6) && Projectile.Distance(Main.dust[i].position) < 150f)
				{
					Main.dust[i].scale /= 1000000f;
					Main.dust[i].active = false;
				}
			}
		}

        public override void OnKill(int timeLeft)
        {
            Player player = Main.player[Projectile.owner];
            var modPlayer = player.GetModPlayer<MPlayer>();
            IEntitySource source = Projectile.GetSource_FromThis(); // Источник для создания нового Projectile

            Projectile.NewProjectile(source, Projectile.Center, Vector2.Zero, ModContent.ProjectileType<NovaFlask_ProjFire>(), Projectile.damage - 30, 0, Main.myPlayer);

            if (Projectile.owner == Main.myPlayer)
            {
                if (player.HasBuff(ModContent.BuffType<PyroBuff>()) && !modPlayer.nitro)
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    int a = Projectile.NewProjectile(source, Projectile.Center, Vector2.Zero, ModContent.ProjectileType<NovaFlask_ProjFire>(), Projectile.damage * 2, 1.5f, Main.myPlayer);
                    Main.projectile[a].scale = 1.5f;
                }

                if (player.HasBuff(ModContent.BuffType<ChemikazeBuff>()) && !modPlayer.nitro)
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    int a = Projectile.NewProjectile(source, Projectile.Center, Vector2.Zero, ModContent.ProjectileType<NovaFlask_ProjFire>(), Projectile.damage * 2, 1.25f, Main.myPlayer);
                    Main.projectile[a].scale = 1.25f;

                    Projectile.NewProjectile(source, Projectile.Center + new Vector2(32, 0), Vector2.Zero, ModContent.ProjectileType<NovaFlask_ProjFire>(), Projectile.damage * 2, 1f, Main.myPlayer);
                    Projectile.NewProjectile(source, Projectile.Center + new Vector2(-32, 0), Vector2.Zero, ModContent.ProjectileType<NovaFlask_ProjFire>(), Projectile.damage * 2, 1f, Main.myPlayer);
                    Projectile.NewProjectile(source, Projectile.Center + new Vector2(0, 32), Vector2.Zero, ModContent.ProjectileType<NovaFlask_ProjFire>(), Projectile.damage * 2, 1f, Main.myPlayer);
                    Projectile.NewProjectile(source, Projectile.Center + new Vector2(0, -32), Vector2.Zero, ModContent.ProjectileType<NovaFlask_ProjFire>(), Projectile.damage * 2, 1f, Main.myPlayer);
                }
                if (player.HasBuff(ModContent.BuffType<CrossBlastBuff>()) && !modPlayer.nitro)
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    IEntitySource entitySource = Projectile.GetSource_FromThis();

                    int a = Projectile.NewProjectile(entitySource, Projectile.Center, Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 1.25f, Projectile.owner);
                    Main.projectile[a].scale = 1.25f;

                    int b = Projectile.NewProjectile(entitySource, Projectile.Center + new Vector2(30, 0), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(entitySource, Projectile.Center + new Vector2(-30, 0), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(entitySource, Projectile.Center + new Vector2(0, 30), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(entitySource, Projectile.Center + new Vector2(0, -30), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 1f, Projectile.owner);

                    int f = Projectile.NewProjectile(entitySource, Projectile.Center + new Vector2(50, 0), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 0.7f, Projectile.owner);
                    Main.projectile[f].scale = 0.7f;
                    int g = Projectile.NewProjectile(entitySource, Projectile.Center + new Vector2(-50, 0), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 0.7f, Projectile.owner);
                    Main.projectile[g].scale = 0.7f;

                    int h = Projectile.NewProjectile(entitySource, Projectile.Center + new Vector2(0, 50), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 0.7f, Projectile.owner);
                    Main.projectile[h].scale = 0.7f;
                    int i = Projectile.NewProjectile(entitySource, Projectile.Center + new Vector2(0, -50), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 0.7f, Projectile.owner);
                    Main.projectile[i].scale = 0.7f;

                    int j = Projectile.NewProjectile(entitySource, Projectile.Center + new Vector2(70, 0), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 0.5f, Projectile.owner);
                    Main.projectile[j].scale = 0.8f;
                    int k = Projectile.NewProjectile(entitySource, Projectile.Center + new Vector2(-70, 0), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 0.5f, Projectile.owner);
                    Main.projectile[k].scale = 0.8f;

                    int l = Projectile.NewProjectile(entitySource, Projectile.Center + new Vector2(0, 70), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 0.5f, Projectile.owner);
                    Main.projectile[l].scale = 0.8f;
                    int m = Projectile.NewProjectile(entitySource, Projectile.Center + new Vector2(0, -70), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 0.5f, Projectile.owner);
                    Main.projectile[m].scale = 0.8f;
                }

                if (player.HasBuff(ModContent.BuffType<RoundBlastBuff>()) && !modPlayer.nitro)
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);

                    Projectile.NewProjectile(source, Projectile.Center + new Vector2(60, 0), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, Projectile.Center + new Vector2(-60, 0), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, Projectile.Center + new Vector2(0, 60), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, Projectile.Center + new Vector2(0, -60), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 1f, Projectile.owner);

                    Projectile.NewProjectile(source, Projectile.Center + new Vector2(40, 40), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, Projectile.Center + new Vector2(-40, 40), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, Projectile.Center + new Vector2(40, -40), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, Projectile.Center + new Vector2(-40, -40), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
                }

                if (player.HasBuff(ModContent.BuffType<SquareBlastBuff>()) && !modPlayer.nitro)
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                   
                    Vector2 sourcePosition = Projectile.position;

                    Projectile.NewProjectile(source, sourcePosition + new Vector2(70, 0), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, sourcePosition + new Vector2(-70, 0), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, sourcePosition + new Vector2(0, 70), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, sourcePosition + new Vector2(0, -70), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, sourcePosition + new Vector2(70, 70), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, sourcePosition + new Vector2(-70, 70), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, sourcePosition + new Vector2(70, -70), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, sourcePosition + new Vector2(-70, -70), Vector2.Zero, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
                }


                if (player.HasBuff(ModContent.BuffType<NitroBuff>()) && !modPlayer.pyro)
                {
                    SoundEngine.PlaySound(SoundID.Item100, Projectile.position);
                     // Источник для снаряда

                    Vector2 position = Projectile.position; // Позиция снаряда
                    Vector2 velocity = Vector2.Zero; // Пустая скорость

                    // Создаем новый снаряд с нужными аргументами
                    int a = Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<NovaBurst>(), Projectile.damage, 1f, Projectile.owner);
                }

                if (player.HasBuff(ModContent.BuffType<ReinforcedBurstBuff>()) && !modPlayer.pyro)
                {
                    SoundEngine.PlaySound(SoundID.Item100, Projectile.position);

                    Vector2 position = Projectile.position;
                    Vector2 velocity = Vector2.Zero;

                    int a = Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<NovaBurst>(), Projectile.damage, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, position + new Vector2(50, 0), velocity, ModContent.ProjectileType<NovaBurst>(), Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, position + new Vector2(-50, 0), velocity, ModContent.ProjectileType<NovaBurst>(), Projectile.damage, 1f, Projectile.owner);
                }


                if (player.HasBuff(ModContent.BuffType<LinearBurstBuff>()) && !modPlayer.pyro)
                {
                    SoundEngine.PlaySound(SoundID.Item100, Projectile.position);
           

                    // Передаем позицию как Vector2 и скорость как Vector2.Zero
                    int a = Projectile.NewProjectile(source, Projectile.position, Vector2.Zero, ModContent.ProjectileType<NovaBurst>(), Projectile.damage, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, Projectile.position + new Vector2(50, 0), Vector2.Zero, ModContent.ProjectileType<NovaBurst>(), Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, Projectile.position + new Vector2(-50, 0), Vector2.Zero, ModContent.ProjectileType<NovaBurst>(), Projectile.damage, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, Projectile.position + new Vector2(100, 0), Vector2.Zero, ModContent.ProjectileType<NovaBurst>(), Projectile.damage, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, Projectile.position + new Vector2(-100, 0), Vector2.Zero, ModContent.ProjectileType<NovaBurst>(), Projectile.damage, 1f, Projectile.owner);
                }

                if (player.HasBuff(ModContent.BuffType<NitroBuff>()) && player.HasBuff(ModContent.BuffType<PyroBuff>()))
                {
                    SoundEngine.PlaySound(SoundID.Item42, Projectile.position);
                   

                    // Создаем снаряд с увеличенным урона и масштаба
                    int a = Projectile.NewProjectile(source, Projectile.position, Vector2.Zero, ModContent.ProjectileType<NovaBurst>(), Projectile.damage * 2, 1.5f, Projectile.owner);
                    Main.projectile[a].scale = 1.5f;

                    // Передаем скорость для снарядов с измененной траекторией
                    int b = Projectile.NewProjectile(source, Projectile.position + new Vector2(20, 0), new Vector2(5, 0), ModContent.ProjectileType<NovaSkull>(), Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, Projectile.position + new Vector2(-20, 0), new Vector2(-5, 0), ModContent.ProjectileType<NovaSkull>(), Projectile.damage, 1f, Projectile.owner);
                }


                if (player.HasBuff(ModContent.BuffType<ReinforcedBurstBuff>()) && player.HasBuff(ModContent.BuffType<PyroBuff>()))
                {
                    SoundEngine.PlaySound(SoundID.Item42, Projectile.position);
                   

                    int a = Projectile.NewProjectile(source, Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<NovaBurst>(), (int)(Projectile.damage * 2), 1.5f, Projectile.owner);
                    Main.projectile[a].scale = 1.5f;

                    int b = Projectile.NewProjectile(source, Projectile.position.X + 10, Projectile.position.Y - 10, 6, 0, ModContent.ProjectileType<NovaSkull>(), Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, Projectile.position.X - 10, Projectile.position.Y - 10, -6, 0, ModContent.ProjectileType<NovaSkull>(), Projectile.damage, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, Projectile.position.X + 40, Projectile.position.Y + 10, 4, 0, ModContent.ProjectileType<NovaSkull>(), Projectile.damage, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, Projectile.position.X - 40, Projectile.position.Y + 10, -4, 0, ModContent.ProjectileType<NovaSkull>(), Projectile.damage, 1f, Projectile.owner);
                }


                if (player.HasBuff(ModContent.BuffType<ReinforcedBurstBuff>()) && player.HasBuff(ModContent.BuffType<PyroBuff>()))
                {
                    SoundEngine.PlaySound(SoundID.Item42, Projectile.position);

                    int a = Projectile.NewProjectile(source, Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<NovaBurst>(), (int)(Projectile.damage * 2), 1.5f, Projectile.owner);
                    Main.projectile[a].scale = 1.5f;

                    int b = Projectile.NewProjectile(source, Projectile.position.X + 10, Projectile.position.Y - 10, 6, 0, ModContent.ProjectileType<NovaSkull>(), Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, Projectile.position.X - 10, Projectile.position.Y - 10, -6, 0, ModContent.ProjectileType<NovaSkull>(), Projectile.damage, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, Projectile.position.X + 40, Projectile.position.Y + 10, 4, 0, ModContent.ProjectileType<NovaSkull>(), Projectile.damage, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, Projectile.position.X - 40, Projectile.position.Y + 10, -4, 0, ModContent.ProjectileType<NovaSkull>(), Projectile.damage, 1f, Projectile.owner);
                }

                if (player.HasBuff(ModContent.BuffType<LinearBurstBuff>()) && player.HasBuff(ModContent.BuffType<PyroBuff>()))
                {
                    SoundEngine.PlaySound(SoundID.Item42, Projectile.position);

                    // Применяем поправки к аргументам
                    int a = Projectile.NewProjectile(source, Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<NovaBurst>(), (int)(Projectile.damage * 2), 1.5f, Projectile.owner);
                    Main.projectile[a].scale = 1.5f;

                    int b = Projectile.NewProjectile(source, Projectile.position.X + 10, Projectile.position.Y - 15, 6, 0, ModContent.ProjectileType<NovaSkull>(), Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, Projectile.position.X - 10, Projectile.position.Y - 15, -6, 0, ModContent.ProjectileType<NovaSkull>(), Projectile.damage, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, Projectile.position.X + 40, Projectile.position.Y, 5, 0, ModContent.ProjectileType<NovaSkull>(), Projectile.damage, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, Projectile.position.X - 40, Projectile.position.Y, -5, 0, ModContent.ProjectileType<NovaSkull>(), Projectile.damage, 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(source, Projectile.position.X + 70, Projectile.position.Y + 15, 4, 0, ModContent.ProjectileType<NovaSkull>(), Projectile.damage, 1f, Projectile.owner);
                    int g = Projectile.NewProjectile(source, Projectile.position.X - 70, Projectile.position.Y + 15, -4, 0, ModContent.ProjectileType<NovaSkull>(), Projectile.damage, 1f, Projectile.owner);
                }


                if (player.HasBuff(ModContent.BuffType<RoundBlastBuff>()) && player.HasBuff(ModContent.BuffType<ReinforcedBurstBuff>()))
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);

                   

                    int z = Projectile.NewProjectile(source, Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<NovaBlast>(), (int)(Projectile.damage * 2), 1.5f, Projectile.owner);
                    Main.projectile[z].scale = 1.25f;

                    int a = Projectile.NewProjectile(source, Projectile.position.X + 65, Projectile.position.Y, 3, 0, ModContent.ProjectileType<NovaSkullburst>(), (int)(Projectile.damage * 2), 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, Projectile.position.X - 65, Projectile.position.Y, -3, 0, ModContent.ProjectileType<NovaSkullburst>(), (int)(Projectile.damage * 2), 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, Projectile.position.X, Projectile.position.Y + 35, 0, 4, ModContent.ProjectileType<NovaSkullburst>(), (int)(Projectile.damage * 2), 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, Projectile.position.X, Projectile.position.Y - 35, 0, -4, ModContent.ProjectileType<NovaSkullburst>(), (int)(Projectile.damage * 2), 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, Projectile.position.X + 50, Projectile.position.Y + 20, 0, 4, ModContent.ProjectileType<NovaSkullburst>(), (int)(Projectile.damage * 2), 1f, Projectile.owner);
                    Main.projectile[e].scale = 1.2f;
                    int f = Projectile.NewProjectile(source, Projectile.position.X - 50, Projectile.position.Y + 20, 0, 4, ModContent.ProjectileType<NovaSkullburst>(), (int)(Projectile.damage * 2), 1f, Projectile.owner);
                    Main.projectile[f].scale = 1.2f;
                    int g = Projectile.NewProjectile(source, Projectile.position.X + 50, Projectile.position.Y - 20, 0, -4, ModContent.ProjectileType<NovaSkullburst>(), (int)(Projectile.damage * 2), 1f, Projectile.owner);
                    Main.projectile[g].scale = 1.2f;
                    int h = Projectile.NewProjectile(source, Projectile.position.X - 50, Projectile.position.Y - 20, 0, -4, ModContent.ProjectileType<NovaSkullburst>(), (int)(Projectile.damage * 2), 1f, Projectile.owner);
                    Main.projectile[h].scale = 1.2f;
                }

                if (player.HasBuff(ModContent.BuffType<RoundBlastBuff>()) && player.HasBuff(ModContent.BuffType<LinearBurstBuff>()))
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);

                    

                    int z = Projectile.NewProjectile(source, Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<NovaBlast>(), (int)(Projectile.damage * 2), 1.5f, Projectile.owner);
                    Main.projectile[z].scale = 1.25f;

                    int a = Projectile.NewProjectile(source, Projectile.position.X + 65, Projectile.position.Y, 3, 0, ModContent.ProjectileType<NovaSkullburst>(), (int)(Projectile.damage * 2), 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, Projectile.position.X - 65, Projectile.position.Y, -3, 0, ModContent.ProjectileType<NovaSkullburst>(), (int)(Projectile.damage * 2), 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, Projectile.position.X, Projectile.position.Y + 35, 0, 4, ModContent.ProjectileType<NovaSkullburst>(), (int)(Projectile.damage * 2), 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, Projectile.position.X, Projectile.position.Y - 35, 0, -4, ModContent.ProjectileType<NovaSkullburst>(), (int)(Projectile.damage * 2), 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, Projectile.position.X + 50, Projectile.position.Y + 20, 0, 4, ModContent.ProjectileType<NovaSkullburst>(), (int)(Projectile.damage * 2), 1f, Projectile.owner);
                    Main.projectile[e].scale = 0.8f;
                    int f = Projectile.NewProjectile(source, Projectile.position.X - 50, Projectile.position.Y + 20, 0, 4, ModContent.ProjectileType<NovaSkullburst>(), (int)(Projectile.damage * 2), 1f, Projectile.owner);
                    Main.projectile[f].scale = 0.8f;
                    int g = Projectile.NewProjectile(source, Projectile.position.X + 50, Projectile.position.Y - 20, 0, -4, ModContent.ProjectileType<NovaSkullburst>(), (int)(Projectile.damage * 2), 1f, Projectile.owner);
                    Main.projectile[g].scale = 0.8f;
                    int h = Projectile.NewProjectile(source, Projectile.position.X - 50, Projectile.position.Y - 20, 0, -4, ModContent.ProjectileType<NovaSkullburst>(), (int)(Projectile.damage * 2), 1f, Projectile.owner);
                    Main.projectile[h].scale = 0.8f;
                    int i = Projectile.NewProjectile(source, Projectile.position.X + 80, Projectile.position.Y + 20, 0, 4, ModContent.ProjectileType<NovaSkullburst>(), (int)(Projectile.damage * 2), 1f, Projectile.owner);
                    Main.projectile[i].scale = 0.6f;
                    int k = Projectile.NewProjectile(source, Projectile.position.X - 80, Projectile.position.Y + 20, 0, 4, ModContent.ProjectileType<NovaSkullburst>(), (int)(Projectile.damage * 2), 1f, Projectile.owner);
                    Main.projectile[k].scale = 0.6f;
                    int l = Projectile.NewProjectile(source, Projectile.position.X + 80, Projectile.position.Y - 20, 0, -4, ModContent.ProjectileType<NovaSkullburst>(), (int)(Projectile.damage * 2), 1f, Projectile.owner);
                    Main.projectile[l].scale = 0.6f;
                    int m = Projectile.NewProjectile(source, Projectile.position.X - 80, Projectile.position.Y - 20, 0, -4, ModContent.ProjectileType<NovaSkullburst>(), (int)(Projectile.damage * 2), 1f, Projectile.owner);
                    Main.projectile[m].scale = 0.6f;
                }

                if (player.HasBuff(ModContent.BuffType<SquareBlastBuff>()) && player.HasBuff(ModContent.BuffType<NitroBuff>()))
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);

                    int d = Projectile.NewProjectile(source, Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<NovaBlast>(), (int)(Projectile.damage * 2), 1f, Projectile.owner);
                    Main.projectile[d].scale = 1.5f;
                    int e = Projectile.NewProjectile(source, Projectile.position.X + 30, Projectile.position.Y + 30, 3, 3, ModContent.ProjectileType<NovaSkull>(), (int)(Projectile.damage * 2), 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(source, Projectile.position.X - 30, Projectile.position.Y + 30, -3, 3, ModContent.ProjectileType<NovaSkull>(), (int)(Projectile.damage * 2), 1f, Projectile.owner);
                    int g = Projectile.NewProjectile(source, Projectile.position.X + 30, Projectile.position.Y - 30, 3, -3, ModContent.ProjectileType<NovaSkull>(), (int)(Projectile.damage * 2), 1f, Projectile.owner);
                    int h = Projectile.NewProjectile(source, Projectile.position.X - 30, Projectile.position.Y - 30, -3, -3, ModContent.ProjectileType<NovaSkull>(), (int)(Projectile.damage * 2), 1f, Projectile.owner);
                }

                if (player.HasBuff(ModContent.BuffType<SquareBlastBuff>()) && player.HasBuff(ModContent.BuffType<ReinforcedBurstBuff>()))
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
                    int d = Projectile.NewProjectile(source, Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[d].scale = 1.5f;
                    int e = Projectile.NewProjectile(source, Projectile.position.X + 30, Projectile.position.Y + 30, 2, 3, ModContent.ProjectileType<NovaSkull>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[e].scale = 0.75f;
                    int f = Projectile.NewProjectile(source, Projectile.position.X - 30, Projectile.position.Y + 30, -2, 3, ModContent.ProjectileType<NovaSkull>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[f].scale = 0.75f;
                    int g = Projectile.NewProjectile(source, Projectile.position.X + 30, Projectile.position.Y - 30, 2, -3, ModContent.ProjectileType<NovaSkull>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[g].scale = 0.75f;
                    int h = Projectile.NewProjectile(source, Projectile.position.X - 30, Projectile.position.Y - 30, -2, -3, ModContent.ProjectileType<NovaSkull>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[h].scale = 0.75f;
                    int i = Projectile.NewProjectile(source, Projectile.position.X + 30, Projectile.position.Y + 30, 3, 2, ModContent.ProjectileType<NovaSkull>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[i].scale = 0.75f;
                    int j = Projectile.NewProjectile(source, Projectile.position.X - 30, Projectile.position.Y + 30, -3, 2, ModContent.ProjectileType<NovaSkull>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[j].scale = 0.75f;
                    int k = Projectile.NewProjectile(source, Projectile.position.X + 30, Projectile.position.Y - 30, 3, -2, ModContent.ProjectileType<NovaSkull>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[k].scale = 0.75f;
                    int l = Projectile.NewProjectile(source, Projectile.position.X - 30, Projectile.position.Y - 30, -3, -2, ModContent.ProjectileType<NovaSkull>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[l].scale = 0.75f;
                }

                if (player.HasBuff(ModContent.BuffType<SquareBlastBuff>()) && player.HasBuff(ModContent.BuffType<LinearBurstBuff>()))
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);

                    int d = Projectile.NewProjectile(source, Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<NovaBlast>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[d].scale = 1.5f;
                    int e = Projectile.NewProjectile(source, Projectile.position.X + 30, Projectile.position.Y + 30, 2, 4, ModContent.ProjectileType<NovaSkull>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[e].scale = 0.65f;
                    int f = Projectile.NewProjectile(source, Projectile.position.X - 30, Projectile.position.Y + 30, -2, 4, ModContent.ProjectileType<NovaSkull>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[f].scale = 0.65f;
                    int g = Projectile.NewProjectile(source, Projectile.position.X + 30, Projectile.position.Y - 30, 2, -4, ModContent.ProjectileType<NovaSkull>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[g].scale = 0.65f;
                    int h = Projectile.NewProjectile(source, Projectile.position.X - 30, Projectile.position.Y - 30, -2, -4, ModContent.ProjectileType<NovaSkull>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[h].scale = 0.65f;
                    int i = Projectile.NewProjectile(source, Projectile.position.X + 30, Projectile.position.Y + 30, 4, 2, ModContent.ProjectileType<NovaSkull>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[i].scale = 0.65f;
                    int j = Projectile.NewProjectile(source, Projectile.position.X - 30, Projectile.position.Y + 30, -4, 2, ModContent.ProjectileType<NovaSkull>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[j].scale = 0.65f;
                    int k = Projectile.NewProjectile(source, Projectile.position.X + 30, Projectile.position.Y - 30, 4, -2, ModContent.ProjectileType<NovaSkull>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[k].scale = 0.65f;
                    int l = Projectile.NewProjectile(source, Projectile.position.X - 30, Projectile.position.Y - 30, -4, -2, ModContent.ProjectileType<NovaSkull>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[l].scale = 0.65f;
                    int m = Projectile.NewProjectile(source, Projectile.position.X + 30, Projectile.position.Y + 30, 3, 3, ModContent.ProjectileType<NovaSkull>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[m].scale = 0.7f;
                    int n = Projectile.NewProjectile(source, Projectile.position.X - 30, Projectile.position.Y + 30, -3, 3, ModContent.ProjectileType<NovaSkull>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[n].scale = 0.7f;
                    int o = Projectile.NewProjectile(source, Projectile.position.X + 30, Projectile.position.Y - 30, 3, -3, ModContent.ProjectileType<NovaSkull>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[o].scale = 0.7f;
                    int p = Projectile.NewProjectile(source, Projectile.position.X - 30, Projectile.position.Y - 30, -3, -3, ModContent.ProjectileType<NovaSkull>(), Projectile.damage * 2, 1f, Projectile.owner);
                    Main.projectile[p].scale = 0.7f;
                }


                if (player.HasBuff(ModContent.BuffType<NitroBuff>()) && player.HasBuff(ModContent.BuffType<ChemikazeBuff>()))
                {
                    SoundEngine.PlaySound(SoundID.Item100, Projectile.position);
                   
                    // Передаем правильные параметры для позиции, направления и урона
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 30, Projectile.position.Y), new Vector2(-2, 0), ModContent.ProjectileType<NovaBurst>(), Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 30, Projectile.position.Y), new Vector2(2, 0), ModContent.ProjectileType<NovaBurst>(), Projectile.damage, 1f, Projectile.owner);
                }

                if (player.HasBuff(ModContent.BuffType<ReinforcedBurstBuff>()) && player.HasBuff(ModContent.BuffType<ChemikazeBuff>()))
                {
                    SoundEngine.PlaySound(SoundID.Item100, Projectile.position);
                    
                    // Здесь также передаем правильные параметры для каждой ракеты
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 40, Projectile.position.Y), new Vector2(-2, 0), ModContent.ProjectileType<NovaBurst>(), Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 40, Projectile.position.Y), new Vector2(2, 0), ModContent.ProjectileType<NovaBurst>(), Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 60, Projectile.position.Y), new Vector2(-3, 0), ModContent.ProjectileType<NovaBurst>(), Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 60, Projectile.position.Y), new Vector2(3, 0), ModContent.ProjectileType<NovaBurst>(), Projectile.damage, 1f, Projectile.owner);
                }


                if (player.HasBuff(ModContent.BuffType<LinearBurstBuff>()) && player.HasBuff(ModContent.BuffType<ChemikazeBuff>()))
                {
                    SoundEngine.PlaySound(SoundID.Item100, Projectile.position);

                    // Используем Vector2 для направления
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 40, Projectile.position.Y), new Vector2(-2, 0), ModContent.ProjectileType<NovaBurst>(), Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 40, Projectile.position.Y), new Vector2(2, 0), ModContent.ProjectileType<NovaBurst>(), Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 60, Projectile.position.Y), new Vector2(-3, 0), ModContent.ProjectileType<NovaBurst>(), Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 60, Projectile.position.Y), new Vector2(3, 0), ModContent.ProjectileType<NovaBurst>(), Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 80, Projectile.position.Y), new Vector2(-4, 0), ModContent.ProjectileType<NovaBurst>(), Projectile.damage, 1f, Projectile.owner);
                    Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 80, Projectile.position.Y), new Vector2(4, 0), ModContent.ProjectileType<NovaBurst>(), Projectile.damage, 1f, Projectile.owner);
                }

                if (player.HasBuff(ModContent.BuffType<CrossBlastBuff>()) && player.HasBuff(ModContent.BuffType<NitroBuff>()))
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);

                    // Создаем новые снаряды с использованием правильных типов данных
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(4, 0), ModContent.ProjectileType<NovaSkullburst>(), Projectile.damage, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(-4, 0), ModContent.ProjectileType<NovaSkullburst>(), Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(0, 4), ModContent.ProjectileType<NovaSkullburst>(), Projectile.damage, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(0, -4), ModContent.ProjectileType<NovaSkullburst>(), Projectile.damage, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 60, Projectile.position.Y), new Vector2(-4, 0), ModContent.ProjectileType<NovaSkullburst>(), Projectile.damage, 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 60, Projectile.position.Y), new Vector2(4, 0), ModContent.ProjectileType<NovaSkullburst>(), Projectile.damage, 1f, Projectile.owner);
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y + 60), new Vector2(0, -4), ModContent.ProjectileType<NovaSkullburst>(), Projectile.damage, 1f, Projectile.owner);
                    int h = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y - 60), new Vector2(0, 4), ModContent.ProjectileType<NovaSkullburst>(), Projectile.damage, 1f, Projectile.owner);
                }

                if (player.HasBuff(ModContent.BuffType<CrossBlastBuff>()) && player.HasBuff(ModContent.BuffType<ReinforcedBurstBuff>()))
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);

                    // Передаем направление как Vector2
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(6, 0), ModContent.ProjectileType<NovaSkullburst>(), Projectile.damage, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(-6, 0), ModContent.ProjectileType<NovaSkullburst>(), Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(0, 6), ModContent.ProjectileType<NovaSkullburst>(), Projectile.damage, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(0, -6), ModContent.ProjectileType<NovaSkullburst>(), Projectile.damage, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 60, Projectile.position.Y), new Vector2(-6, 0), ModContent.ProjectileType<NovaSkullburst>(), Projectile.damage, 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 60, Projectile.position.Y), new Vector2(6, 0), ModContent.ProjectileType<NovaSkullburst>(), Projectile.damage, 1f, Projectile.owner);
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y + 60), new Vector2(0, -6), ModContent.ProjectileType<NovaSkullburst>(), Projectile.damage, 1f, Projectile.owner);
                    int h = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y - 60), new Vector2(0, 6), ModContent.ProjectileType<NovaSkullburst>(), Projectile.damage, 1f, Projectile.owner);
                }

                if (player.HasBuff(ModContent.BuffType<CrossBlastBuff>()) && player.HasBuff(ModContent.BuffType<LinearBurstBuff>()))
                {
                    SoundEngine.PlaySound(SoundID.Item62, Projectile.position);

                    // Передаем направление как Vector2
                    int a = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(8, 0), ModContent.ProjectileType<NovaSkullburst>(), Projectile.damage, 1f, Projectile.owner);
                    int b = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(-8, 0), ModContent.ProjectileType<NovaSkullburst>(), Projectile.damage, 1f, Projectile.owner);
                    int c = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(0, 8), ModContent.ProjectileType<NovaSkullburst>(), Projectile.damage, 1f, Projectile.owner);
                    int d = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y), new Vector2(0, -8), ModContent.ProjectileType<NovaSkullburst>(), Projectile.damage, 1f, Projectile.owner);
                    int e = Projectile.NewProjectile(source, new Vector2(Projectile.position.X + 60, Projectile.position.Y), new Vector2(-8, 0), ModContent.ProjectileType<NovaSkullburst>(), Projectile.damage, 1f, Projectile.owner);
                    int f = Projectile.NewProjectile(source, new Vector2(Projectile.position.X - 60, Projectile.position.Y), new Vector2(8, 0), ModContent.ProjectileType<NovaSkullburst>(), Projectile.damage, 1f, Projectile.owner);
                    int g = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y + 60), new Vector2(0, -8), ModContent.ProjectileType<NovaSkullburst>(), Projectile.damage, 1f, Projectile.owner);
                    int h = Projectile.NewProjectile(source, new Vector2(Projectile.position.X, Projectile.position.Y - 60), new Vector2(0, 8), ModContent.ProjectileType<NovaSkullburst>(), Projectile.damage, 1f, Projectile.owner);
                }

            }
        }
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			Projectile.Kill();
		}

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            Projectile.damage = 0; // Урон NPC устанавливается в 0
        }
    }
}