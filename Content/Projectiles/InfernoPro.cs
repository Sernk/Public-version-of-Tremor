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

namespace TremorMod.Content.Projectiles
{
	public class InfernoPro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 122;
			Projectile.height = 122;
			Projectile.scale = 1.1f;
			Projectile.aiStyle = 19;
			Projectile.timeLeft = 90;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.light = 0.9f;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.penetrate = -1;
			Projectile.ownerHitCheck = true;
			Projectile.hide = true;
		}

        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Inferno");
		}*/

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            // Обновление направления игрока и привязка проектиля
            player.direction = Projectile.direction;
            player.heldProj = Projectile.whoAmI;
            player.itemTime = player.itemAnimation;

            // Центрирование проектиля относительно игрока
            Projectile.position.X = player.position.X + player.width / 2 - Projectile.width / 2;
            Projectile.position.Y = player.position.Y + player.height / 2 - Projectile.height / 2;

            // Обновление позиции проектиля с учётом его скорости
            Projectile.position += Projectile.velocity * Projectile.ai[0];

            if (Projectile.ai[0] == 0f)
            {
                Projectile.ai[0] = 3f; // Установка начального значения ai[0]
                Projectile.netUpdate = true;
            }

            // Проверка анимации предмета
            if (player.itemAnimation < player.itemAnimationMax / 3)
            {
                Projectile.ai[0] -= 1.1f;

                // Проверка локального AI проектиля
                if (Projectile.localAI[0] == 0f && Main.myPlayer == Projectile.owner)
                {
                    Projectile.localAI[0] = 1f;

                    // Проверка столкновений
                    Vector2 futurePosition = new Vector2(
                        Projectile.Center.X + Projectile.velocity.X * Projectile.ai[0],
                        Projectile.Center.Y + Projectile.velocity.Y * Projectile.ai[0]
                    );

                    if (Collision.CanHit(player.position, player.width, player.height, futurePosition, Projectile.width, Projectile.height))
                    {
                        var source = Projectile.GetSource_FromAI();

                        // Создание нового проектиля
                        int z = Projectile.NewProjectile(
                            source,
                            Projectile.Center,
                            Projectile.velocity * 1.5f,
                            706, // Тип нового проектиля
                            Projectile.damage,
                            Projectile.knockBack * 0.85f,
                            Projectile.owner
                        );

                        // Настройка нового проектиля
                        Main.projectile[z].tileCollide = false;
                        Main.projectile[z].timeLeft = 240;
                    }
                }
            }
        

			else
			{
				Projectile.ai[0] += 0.75f;
			}

			if (Main.player[Projectile.owner].itemAnimation == 0)
			{
				Projectile.Kill();
			}
		}
	}
}
