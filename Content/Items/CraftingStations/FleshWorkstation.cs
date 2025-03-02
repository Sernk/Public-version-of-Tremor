using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Tiles;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.CraftingStations
{
	public class FleshWorkstation : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 48;
			Item.height = 32;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useStyle = 1;
			Item.rare = 1;
			Item.consumable = true;
			Item.value = 200;
			Item.createTile = ModContent.TileType<FleshWorkstationTile>();
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flesh Workstation");
			Tooltip.SetDefault("");
		}*/

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 15);
			recipe.AddIngredient(ModContent.ItemType<UntreatedFlesh>(), 10);
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
