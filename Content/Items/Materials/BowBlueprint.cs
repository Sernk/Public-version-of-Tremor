using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Materials
{
	public class BowBlueprint : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 30;
			Item.height = 24;
			Item.maxStack = 999;
			Item.value = 10000;
			Item.rare = 6;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Bow Blueprint");
			// Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<TornPapyrus>(), 1);
			recipe.AddIngredient(ModContent.ItemType<TearsofDeath>(), 1);
			recipe.AddIngredient(ModContent.ItemType<CursedInk>(), 1);
			recipe.AddTile(ModContent.TileType<NecromaniacWorkbenchTile>());
			recipe.Register();
		}
	}
}
