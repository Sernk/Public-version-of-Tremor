using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Tiles.GloomstoneTiles;

namespace TremorMod.Content.Items.Placeable.GloomstonePlaceable
{
	public class GloomstoneBrickWall : ModItem
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
			Item.createWall = ModContent.WallType<GloomstoneBrickWallTile>();
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Gloomstone Brick Wall");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<GloomstoneBrick>(), 1);
			//recipe.SetResult(this, 4);
			recipe.AddTile(17);
			recipe.Register();
		}
	}
}
