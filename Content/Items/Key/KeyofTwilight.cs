using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Key
{
	public class KeyofTwilight : ModItem
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
			DisplayName.SetDefault("Key of Jungles");
			Tooltip.SetDefault("'Charged with the essence of jungle grass'");
		}*/

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.GoldenKey, 1);
			recipe.AddIngredient(ItemID.SoulofLight, 6);
			recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddIngredient(ItemID.Vine, 2);
			recipe.AddIngredient(ItemID.Stinger, 1);
			recipe.AddIngredient(ItemID.JungleSpores, 3);
			//recipe.SetResult(this);
			recipe.AddTile(134);
            recipe.Register();
        }
	}
}
