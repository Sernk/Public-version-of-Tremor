using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Tiles.Stone;

namespace TremorMod.Content.Items.Placeable.Stone
{
	public class StoneGrandfatherClock : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 32;
			Item.height = 74;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useStyle = 1;
			Item.rare = 1;
			Item.consumable = true;
			Item.value = 0;
			Item.createTile = ModContent.TileType<StoneGrandfatherClockTile>();
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Stone Grandfather Clock");
			// Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IronBar, 3);
			recipe.AddIngredient(ItemID.Glass, 6);
			recipe.AddIngredient(3, 10);
			//recipe.SetResult(this);
			recipe.AddTile(17);
			recipe.Register();

			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ItemID.LeadBar, 3);
			recipe1.AddIngredient(ItemID.Glass, 6);
			recipe1.AddIngredient(3, 10);
			//recipe.SetResult(this);
			recipe1.AddTile(17);
			recipe1.Register();
		}
	}
}