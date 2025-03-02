using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TremorMod.Content.Items.CogLordItems;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Materials.OreAndBar
{
	public class BrassBar : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 30;
			Item.height = 24;
			Item.maxStack = 99;
			Item.value = 300;
			Item.rare = 5;
			Item.createTile = ModContent.TileType<BrassBarTile>();
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brass Bar");
			Tooltip.SetDefault("");
		}*/

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BrassNugget>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Charcoal>(), 2);
            //recipe.SetResult(this);
            recipe.AddTile(ModContent.TileType<BlastFurnaceTile>());
            recipe.Register();
		}
	}
}
