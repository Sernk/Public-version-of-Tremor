using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Key
{
	public class KeyofSands : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 26;
			Item.maxStack = 99;
			Item.height = 26;
			Item.rare = 0;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Key of Sands");
			Tooltip.SetDefault("'Charged with the essence of sands'");
		}*/

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.GoldenKey, 1);
			recipe.AddIngredient(3783, 6);
			recipe.AddIngredient(ItemID.SandBlock, 10);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
