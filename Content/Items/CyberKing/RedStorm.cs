using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.CyberKing
{
    public class RedStorm : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 64;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 22;
            Item.height = 46;
            Item.useTime = 7;
            Item.useAnimation = 7; // Быстрое время анимации
            Item.useStyle = ItemUseStyleID.Shoot; // Стрелять
            Item.shootSpeed = 30f; // Скорость снаряда
            Item.shoot = ModContent.ProjectileType<RedStormProjectile>(); // Используем наш кастомный снаряд
            Item.knockBack = 3;
            Item.useAmmo = AmmoID.Arrow; // Используем стрелы
            Item.value = 85000;
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return !Main.rand.NextBool(2); // 50% шанс не расходовать боеприпасы
        }

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // Смещение позиции при стрельбе
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
            position += muzzleOffset;

            // Создаем кастомный снаряд
            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<RedStormProjectile>(), damage, knockback, player.whoAmI);

            return false; // Отключаем стандартный выстрел
        }
    }
}