using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Placeable
{
	public class SandstoneChest : ModItem
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
			Item.createTile = ModContent.TileType<SandstoneChestTile>();
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sandstone Chest");
			Tooltip.SetDefault("");
		}*/

		public override void AddRecipes()
		{
			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(607, 8);
			recipe1.AddIngredient(ItemID.IronBar, 2);
			//recipe.SetResult(this);
			recipe1.AddTile(17);
			recipe1.Register();

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(607, 8);
			recipe2.AddIngredient(ItemID.LeadBar, 2);
			//recipe.SetResult(this);
			recipe2.AddTile(17);
			recipe2.Register();
		}
	}
}
