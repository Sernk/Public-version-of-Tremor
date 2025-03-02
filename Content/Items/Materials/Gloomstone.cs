using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Tiles;
using TremorMod.Content.Items.Placeable;

namespace TremorMod.Content.Items.Materials
{
	public class Gloomstone : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 12;
			Item.height = 12;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.value = 100;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.rare = 3;
			Item.useStyle = 1;
			Item.consumable = true;
            Item.createTile = ModContent.TileType<GloomstoneTile>();
        }

        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gloomstone");
			Tooltip.SetDefault("");
		}*/

        public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<GloomstoneWallItem>(), 4);
			//recipe.SetResult(this, 1);
			recipe.AddTile(17);
            recipe.Register();
        }
	}
}
