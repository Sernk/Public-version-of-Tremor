using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.NPCsDrop;

namespace TremorMod.Content.Items.Key
{
	public class KeyofOcean : ModItem
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
			DisplayName.SetDefault("Key of Ocean");
			Tooltip.SetDefault("'Charged with the essence of ocean'");
		}*/

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.GoldenKey, 1);
			recipe.AddIngredient(ModContent.ItemType<SeaFragment>(), 12);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
