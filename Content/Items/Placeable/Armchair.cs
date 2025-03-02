using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Placeable
{
	public class Armchair : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 42;
			Item.height = 32;
			Item.maxStack = 999;
			Item.value = 100;
			Item.rare = 1;
            Item.createTile = ModContent.TileType<ArmchairTile>();
            Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Armchair");
			Tooltip.SetDefault("");
		}*/

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 15);
			recipe.AddIngredient(ItemID.Silk, 6);
			//recipe.SetResult(this);
			recipe.AddTile(106);
            recipe.Register();
        }
	}
}
