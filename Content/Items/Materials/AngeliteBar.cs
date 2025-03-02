using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Materials
{
	public class AngeliteBar : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 30; 
			Item.height = 24;
			Item.maxStack = 99;
			Item.value = 17500;
			Item.rare = 0;
            Item.createTile = ModContent.TileType<AngeliteBarTile>();
            Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Angelite Bar");
			Tooltip.SetDefault("");
		}*/

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AngeliteOre>(), 6);
            //recipe.SetResult(this);
            recipe.AddTile(412);
			recipe.Register();
		}
	}
}
