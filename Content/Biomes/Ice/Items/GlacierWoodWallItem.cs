using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Biomes.Ice.Items
{
	public class GlacierWoodWallItem : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 12;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 7;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.createWall = ModContent.WallType<GlacierWoodWallWall>();
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glacier Wood Wall");
			Tooltip.SetDefault("");
		}*/

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<GlacierWood>(), 1);
			//recipe.SetResult(this, 4);
			recipe.AddTile(18);
			recipe.Register();
		}
	}
}
