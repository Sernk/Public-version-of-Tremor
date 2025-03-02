using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.CraftingStations
{
	public class DevilForge : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 50;
			Item.height = 26;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.value = 150;
			Item.createTile = ModContent.TileType<DevilForgeTile>();
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Devil Forge");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<DemonBlood>(), 5);
			recipe.AddIngredient(ItemID.Hellstone, 25);
			recipe.AddIngredient(ItemID.Obsidian, 10);
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
