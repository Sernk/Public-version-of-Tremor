using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Placeable
{
	public class GloomstoneWallItem : ModItem
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
			Item.rare = 3;
			Item.consumable = true;
            Item.createWall = ModContent.WallType<GloomstoneWall>();
        }

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gloomstone Wall");
			Tooltip.SetDefault("");
		}*/

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe = Recipe.Create(ModContent.ItemType<GloomstoneWallItem>(), 4);
            recipe.AddIngredient(ModContent.ItemType<Gloomstone>(), 1);
			//recipe.SetResult(this, 4);
			recipe.AddTile(17);
            recipe.Register();	
        }
	}
}
