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

namespace TremorMod.Content.NPCs.Bosses.AndasBoss
{
	[AutoloadBossHead]
	public class Andas : ModNPC
	{

        public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Andas");
			Main.npcFrameCount[NPC.type] = 3;
		}

		public override void SetDefaults()
		{
			NPC.aiStyle = -1;
			NPC.width = 66;
			NPC.height = 88;
			NPC.damage = 52;
			NPC.defense = 170;
			NPC.lifeMax = 90000;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath5;
			NPC.knockBackResist = 0f;
			NPC.noTileCollide = true;
			NPC.noGravity = true;
			NPC.boss = true;
            if (ModLoader.HasMod("TremorModMusic"))
            {
                Mod musicMod = ModLoader.GetMod("TremorModMusic");
                if (musicMod != null)
                {
                    Music = MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Andas");
                }
            }
            else
            {
                Music = MusicID.Boss1; // Ванильная музыка
            }
            NPC.buffImmune[24] = true;
			NPC.buffImmune[67] = true;
			NPC.lavaImmune = true;
		}

		private Vector2 CalculateVelocity(Vector2 start, Vector2 end, float speed)
		{
			Vector2 direction = end - start; // Вектор направления
			direction.Normalize(); // Нормализация вектора
			return direction * speed; // Умножаем нормализованный вектор на скорость
		}


		#region Settings AI
		const int ShootType = 467;
		const int ShootDamage = 40;
		const float ShootKnockback = 0.8554f;
		const int ShootCount = 5;
		const int ShootSpeed = 3;
		const int ShootDirection = 7;
		const float Speed = 14f;
		const float Acceleration = 0.1f;
		int Timer;
		#endregion

		//@todo
		public override void AI()
		{
			NPC.TargetClosest(true);
			NPC.spriteDirection = NPC.direction;
			Player player = Main.player[NPC.target];

			// Проверка, жив ли игрок
			if (player.dead || !player.active)
			{
				NPC.TargetClosest(false);
				NPC.active = false;
				return;
			}

			Timer++;

			if (Timer >= 0)
			{
				if ((int)(Main.time % 90) == 0)
				{
					// Вычисляем скорость от NPC до игрока
					Vector2 velocity = CalculateVelocity(NPC.Center, new Vector2(player.Center.X, player.Center.Y + 20), 10);

					// Добавляем случайный разброс
					int spread = 65;
					float spreadMult = 0.05f;
					velocity.X += Main.rand.Next(-spread, spread + 1) * spreadMult;
					velocity.Y += Main.rand.Next(-spread, spread + 1) * spreadMult;

					// Создаем снаряд
					IEntitySource entitySource = NPC.GetSource_FromAI();
					int projectileIndex = Projectile.NewProjectile(entitySource, NPC.Center, velocity, 258, ShootDamage, ShootKnockback, Main.myPlayer);

					// Настройка снаряда
					if (projectileIndex >= 0 && projectileIndex < Main.maxProjectiles)
					{
						Projectile projectile = Main.projectile[projectileIndex];
						projectile.hostile = true;
						projectile.friendly = false;
						projectile.tileCollide = false;
					}
				}
			}
			if (Timer >= 0 && Timer <= 1000) //flight
			{
				Vector2 StartPosition = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
				float DirectionX = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - StartPosition.X;
				float DirectionY = Main.player[NPC.target].position.Y + (Main.player[NPC.target].height / 2) - 120 - StartPosition.Y;
				float Length = (float)Math.Sqrt(DirectionX * DirectionX + DirectionY * DirectionY);
				float Num = Speed / Length;
				DirectionX = DirectionX * Num;
				DirectionY = DirectionY * Num;
				if (NPC.velocity.X < DirectionX)
				{
					NPC.velocity.X = NPC.velocity.X + Acceleration;
					if (NPC.velocity.X < 0 && DirectionX > 0)
						NPC.velocity.X = NPC.velocity.X + Acceleration;
				}
				else if (NPC.velocity.X > DirectionX)
				{
					NPC.velocity.X = NPC.velocity.X - Acceleration;
					if (NPC.velocity.X > 0 && DirectionX < 0)
						NPC.velocity.X = NPC.velocity.X - Acceleration;
				}
				if (NPC.velocity.Y < DirectionY)
				{
					NPC.velocity.Y = NPC.velocity.Y + Acceleration;
					if (NPC.velocity.Y < 0 && DirectionY > 0)
						NPC.velocity.Y = NPC.velocity.Y + Acceleration;
				}
				else if (NPC.velocity.Y > DirectionY)
				{
					NPC.velocity.Y = NPC.velocity.Y - Acceleration;
					if (NPC.velocity.Y > 0 && DirectionY < 0)
						NPC.velocity.Y = NPC.velocity.Y - Acceleration;
				}
				if (Main.rand.Next(36) == 1)
				{
					Vector2 StartPosition2 = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height / 2));
					float AndasRotation = (float)Math.Atan2(StartPosition2.Y - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), StartPosition2.X - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
					NPC.velocity.X = (float)(Math.Cos(AndasRotation) * 18) * -1;
					NPC.velocity.Y = (float)(Math.Sin(AndasRotation) * 18) * -1;
					NPC.netUpdate = true;
				}
			}

			if (Timer == 700)
			{
				for (int i = 0; i < 50; i++)
				{
					int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, 6);
					Main.dust[dust].scale = 1.5f;
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 0f;
					Main.dust[dust].velocity *= 0f;
				}
				DoAndasShoot();
				NPC.position.X = (Main.player[NPC.target].position.X - 500) + Main.rand.Next(1000);
				NPC.position.Y = (Main.player[NPC.target].position.Y - 500) + Main.rand.Next(1000);
			}

			if (Timer == 850)
			{
				for (int i = 0; i < 50; i++)
				{
					int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, 6);
					Main.dust[dust].scale = 1.5f;
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 0f;
					Main.dust[dust].velocity *= 0f;
				}
				DoAndasShoot();
				NPC.position.X = (Main.player[NPC.target].position.X - 500) + Main.rand.Next(1000);
				NPC.position.Y = (Main.player[NPC.target].position.Y - 500) + Main.rand.Next(1000);
			}

			if (Timer == 1000)
			{
				for (int i = 0; i < 50; i++)
				{
					int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, 6);
					Main.dust[dust].scale = 1.5f;
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 0f;
					Main.dust[dust].velocity *= 0f;
				}
				DoAndasShoot();
				NPC.position.X = (Main.player[NPC.target].position.X - 500) + Main.rand.Next(1000);
				NPC.position.Y = (Main.player[NPC.target].position.Y - 500) + Main.rand.Next(1000);
			}

			if (Timer == 1150)
			{
				for (int i = 0; i < 50; i++)
				{
					int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, 6);
					Main.dust[dust].scale = 1.5f;
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 0f;
					Main.dust[dust].velocity *= 0f;
				}
				DoAndasShoot();
				NPC.position.X = (Main.player[NPC.target].position.X - 500) + Main.rand.Next(1000);
				NPC.position.Y = (Main.player[NPC.target].position.Y - 500) + Main.rand.Next(1000);
			}

			if (Timer == 1300)
			{
				for (int i = 0; i < 50; i++)
				{
					int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, 6);
					Main.dust[dust].scale = 1.5f;
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 0f;
					Main.dust[dust].velocity *= 0f;
				}
				DoAndasShoot();
				NPC.position.X = (Main.player[NPC.target].position.X - 500) + Main.rand.Next(1000);
				NPC.position.Y = (Main.player[NPC.target].position.Y - 500) + Main.rand.Next(1000);
			}

			if (Timer > 1300)
			{
				Timer = 0;
			}
		}

		void DoAndasShoot()
		{
			// Получаем источник (для использования в новом API)
			IEntitySource entitySource = NPC.GetSource_FromAI();

			// Создаем проектиль, указывая корректные типы для аргументов:
			Projectile.NewProjectile(entitySource, NPC.position + new Vector2(40, 40), new Vector2(-ShootDirection, 0), ShootType, ShootDamage, ShootKnockback, Main.myPlayer);
			Projectile.NewProjectile(entitySource, NPC.position + new Vector2(40, 40), new Vector2(ShootDirection, 0), ShootType, ShootDamage, ShootKnockback, Main.myPlayer);
			Projectile.NewProjectile(entitySource, NPC.position + new Vector2(40, 40), new Vector2(0, ShootDirection), ShootType, ShootDamage, ShootKnockback, Main.myPlayer);
			Projectile.NewProjectile(entitySource, NPC.position + new Vector2(40, 40), new Vector2(0, -ShootDirection), ShootType, ShootDamage, ShootKnockback, Main.myPlayer);
			Projectile.NewProjectile(entitySource, NPC.position + new Vector2(40, 40), new Vector2(-ShootDirection, -ShootDirection), ShootType, ShootDamage, ShootKnockback, Main.myPlayer);
			Projectile.NewProjectile(entitySource, NPC.position + new Vector2(40, 40), new Vector2(ShootDirection, -ShootDirection), ShootType, ShootDamage, ShootKnockback, Main.myPlayer);
			Projectile.NewProjectile(entitySource, NPC.position + new Vector2(40, 40), new Vector2(-ShootDirection, ShootDirection), ShootType, ShootDamage, ShootKnockback, Main.myPlayer);
			Projectile.NewProjectile(entitySource, NPC.position + new Vector2(40, 40), new Vector2(ShootDirection, ShootDirection), ShootType, ShootDamage, ShootKnockback, Main.myPlayer);
		}


        // Переопределение метода для рисования NPC
        /*public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            // Получаем текстуру NPC (замените на путь к вашей текстуре)
            Texture2D drawTexture = ModContent.Request<Texture2D>("TremorMod.Content.NPCs.Bosses.AndasBoss").Value;
            Vector2 origin = new Vector2(drawTexture.Width / 2, drawTexture.Height / Main.npcFrameCount[NPC.type] / 2);

            // Рисуем NPC
            Vector2 drawPos = new Vector2(
                NPC.position.X - Main.screenPosition.X + NPC.width / 2 - drawTexture.Width / 2 * NPC.scale + origin.X * NPC.scale,
                NPC.position.Y - Main.screenPosition.Y + NPC.height - drawTexture.Height * NPC.scale / Main.npcFrameCount[NPC.type] + origin.Y * NPC.scale + NPC.gfxOffY);

            // Отражение спрайта по оси X
            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            spriteBatch.Draw(drawTexture, drawPos, NPC.frame, lightColor, NPC.rotation, origin, NPC.scale, effects, 0f);
            return false;
        }*/

        public override void OnKill()
        {
           
            IEntitySource source = NPC.GetSource_FromAI();
			Vector2 bossCenter = NPC.Center;

			int cyberKingID = ModContent.NPCType<TrueAndas>();
            NPC.NewNPC(source, (int)bossCenter.X, (int)bossCenter.Y, cyberKingID, 0, 0, 0, 0, 0, NPC.target);

            Player player = Main.player[NPC.target];
            SoundEngine.PlaySound(SoundID.Roar, player.position);
        }

    }
}