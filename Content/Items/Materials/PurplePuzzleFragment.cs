using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class PurplePuzzleFragment : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 24;
			Item.maxStack = 99;
			Item.value = 10000;
			Item.rare = 3;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Purple Puzzle Fragment");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<PhantomSoul>(), 4);
			recipe.AddIngredient(ItemID.Amethyst, 8);
			recipe.AddIngredient(ItemID.SoulofNight, 2);
			//recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.Register();
		}
	}
}