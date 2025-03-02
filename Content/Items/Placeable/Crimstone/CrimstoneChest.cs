using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Tiles.Crimstone;

namespace TremorMod.Content.Items.Placeable.Crimstone
{
	public class CrimstoneChest : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 18;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useStyle = 1;
			Item.rare = 1;
			Item.consumable = true;
			Item.value = 2000;
			Item.createTile = ModContent.TileType<CrimstoneChestTile>();
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Crimstone Chest");
			// Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(836, 8);
			recipe1.AddIngredient(1257, 1);
			recipe1.AddIngredient(ItemID.IronBar, 2);
			recipe1.AddTile(17);
			recipe1.Register();

			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(836, 8);
			recipe.AddIngredient(1257, 1);
			recipe.AddIngredient(ItemID.LeadBar, 2);
			recipe.AddTile(17);
			recipe.Register();
		}
	}
}
