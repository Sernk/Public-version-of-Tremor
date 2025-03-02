using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Materials
{
	public class CollapsiumBar : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 24;
			Item.maxStack = 99;
			Item.value = 17500;
			Item.rare = 0;
			Item.createTile = ModContent.TileType<CollapsiumBarTile>();
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
		}

        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Collapsium Bar");
			Tooltip.SetDefault("");
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


        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<CollapsiumOre>(), 6);
			//recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.Register();
		}
	}
}
