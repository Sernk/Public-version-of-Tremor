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
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Filters = Terraria.Graphics.Effects.Filters;

namespace TremorMod.Content.Projectiles
{
	public class GurdPet : ModProjectile
	{
		public override void SetDefaults()
		{
            Main.projFrames[Projectile.type] = 8;
            Projectile.width = 46;
            Projectile.height = 38;
            Projectile.aiStyle = -1; // Убираем стандартный AI
            Projectile.friendly = true;
            Projectile.penetrate = -1; // Питомец не уничтожается
            Projectile.timeLeft = 2; // Постоянно обновляется
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true; // Питомец может сталкиваться с плитками
        }

        public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Gurd Pet");
            Main.projPet[Projectile.type] = true; // Пометка как питомца
		}

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            // Проверяем, жив ли игрок
            if (player.dead || !player.active)
            {
                player.ClearBuff(ModContent.BuffType<Buffs.GurdPetBuff>());
            }

            // Проверяем, есть ли бафф питомца
            if (player.HasBuff(ModContent.BuffType<Buffs.GurdPetBuff>()))
            {
                Projectile.timeLeft = 2; // Поддерживаем существование
            }

            // Привязка к игроку
            Vector2 playerPosition = player.Center + new Vector2(-50f, 0f); // Смещение относительно игрока
            float distanceToPlayer = Vector2.Distance(Projectile.Center, playerPosition);

            if (distanceToPlayer > 1000f) // Если питомец слишком далеко, телепортируем его
            {
                Projectile.Center = playerPosition;
            }

            // Ходьба по плиткам
            float speed = 2f; // Скорость движения
            float inertia = 20f;

            if (Projectile.Center.X < player.Center.X - 60f) // Идти вправо
            {
                Projectile.velocity.X = (Projectile.velocity.X * (inertia - 1) + speed) / inertia;
            }
            else if (Projectile.Center.X > player.Center.X + 60f) // Идти влево
            {
                Projectile.velocity.X = (Projectile.velocity.X * (inertia - 1) - speed) / inertia;
            }
            else // Если рядом с игроком, замедляемся
            {
                Projectile.velocity.X *= 0.9f;
            }

            // Проверка на землю
            Point tileBelowPosition = (Projectile.Bottom / 16).ToPoint() + new Point(0, 1); // Координаты плитки под питомцем
            Tile tileBelow = Framing.GetTileSafely(tileBelowPosition.X, tileBelowPosition.Y);

            if (Projectile.velocity.Y == 0f) // Если на земле
            {
                if (!tileBelow.HasTile || !Main.tileSolid[tileBelow.TileType]) // Если плитки нет, падаем
                {
                    Projectile.velocity.Y += 0.4f;
                }
            }
            else // Если в воздухе, ускоряем падение
            {
                Projectile.velocity.Y += 0.4f;
            }

            // Ограничение вертикальной скорости
            if (Projectile.velocity.Y > 10f)
            {
                Projectile.velocity.Y = 10f;
            }

            // Устанавливаем направление питомца
            Projectile.spriteDirection = Projectile.velocity.X > 0 ? 1 : -1;

            // Анимация
            if (Projectile.velocity.X != 0)
            {
                Projectile.frameCounter++;
                if (Projectile.frameCounter >= 8) // Скорость смены кадров
                {
                    Projectile.frameCounter = 0;
                    Projectile.frame = (Projectile.frame + 1) % Main.projFrames[Projectile.type];
                }
            }
            else
            {
                Projectile.frame = 0; // Если стоит, показываем первый кадр
            }
        }
    }
}
