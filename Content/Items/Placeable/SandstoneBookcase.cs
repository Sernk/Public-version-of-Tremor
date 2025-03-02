using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Placeable
{
	public class SandstoneBookcase : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 42;
			Item.height = 16;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useStyle = 1;
			Item.rare = 1;
			Item.consumable = true;
			Item.value = 2000;
			Item.createTile = ModContent.TileType<SandstoneBookcaseTile>();
		}

        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sandstone Bookcase");
			Tooltip.SetDefault("");
		}*/

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(607, 15);
            recipe.AddIngredient(ItemID.Silk, 5);
            //recipe.SetResult(this);
            recipe.AddTile(17);
            recipe.Register();
        }
    }
}
