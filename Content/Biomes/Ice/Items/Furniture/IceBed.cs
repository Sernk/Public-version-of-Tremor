using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Biomes.Ice.Items.Furniture;

namespace TremorMod.Content.Biomes.Ice.Items.Furniture
{
	public class IceBed : ModItem
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Glacier Wood Bed");
			//Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			Item.width = 64;
			Item.height = 26;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useStyle = 1;
			Item.rare = 1;
			Item.consumable = true;
			Item.value = 2000;
			Item.createTile = ModContent.TileType<IceBedTile>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<GlacierWood>(), 15);
			recipe.AddIngredient(ItemID.Silk, 5);
			//recipe.SetResult(this);
			recipe.AddTile(106);
			recipe.Register();
		}
	}
}