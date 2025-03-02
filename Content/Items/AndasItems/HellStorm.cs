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
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.AndasItems
{
	public class HellStorm : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 220;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 32;
			Item.height = 78;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.channel = true;
			Item.knockBack = 5f;
			Item.value = 10000000;
			Item.rare = 0;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<HellStormProj>();
			Item.shootSpeed = 20f;
			Item.useAmmo = AmmoID.Arrow;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hell Storm");
			Tooltip.SetDefault("Shoots out homing hell arrows\n" +
			"The amount of arrows shot increases when used for longer time");
		}*/

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			foreach (var tooltip in tooltips)
			{
				// Меняем цвет текста для названия предмета
				if (tooltip.Mod == "Terraria" && tooltip.Name == "ItemName")
				{
					tooltip.OverrideColor = new Color(238, 194, 73); // Цвет золота
				}
			}
		}

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // Смещение позиции при стрельбе
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
            position += muzzleOffset;

            // Создаем кастомный снаряд
            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<HellStormProj>(), damage, knockback, player.whoAmI);

            return false; // Отключаем стандартный выстрел
        }
    }
}
