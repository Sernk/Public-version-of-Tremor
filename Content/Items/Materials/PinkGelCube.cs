using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class PinkGelCube : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 24;
			Item.maxStack = 99;
			Item.value = 60;
			Item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Pink Gel Cube");
			//Tooltip.SetDefault("Alchemically important ingredient");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.PinkGel, 5);
			//recipe.SetResult(this);
			recipe.AddTile(13);
			recipe.Register();
		}
	}
}