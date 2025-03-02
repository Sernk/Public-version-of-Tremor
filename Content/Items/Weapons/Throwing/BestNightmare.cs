using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Throwing
{
	public class BestNightmare : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 260;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 50;
			Item.shootSpeed = 30f;
			Item.useAnimation = 50;
			Item.useStyle = 1;
			Item.knockBack = 9f;
			Item.shoot = ModContent.ProjectileType<BestNightmarePro>();
			Item.value = 27600;
			Item.rare = 0;
			Item.noUseGraphic = true;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Best Nightmare");
			//Tooltip.SetDefault("");
		}

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
    }
}
