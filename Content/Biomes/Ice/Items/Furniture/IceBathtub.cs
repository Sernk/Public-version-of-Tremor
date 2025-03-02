using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Biomes.Ice.Items.Furniture
{
	public class IceBathtub : ModItem
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Glacier Wood Bathtub");
			//Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			Item.width = 64;
			Item.height = 32;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useStyle = 1;
			Item.rare = 1;
			Item.consumable = true;
			Item.value = 2000;
			Item.createTile = ModContent.TileType<IceBathtubTile>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<GlacierWood>(), 14);
			//recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.Register();
		}
	}
}