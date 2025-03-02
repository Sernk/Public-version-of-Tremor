using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles.GloomstoneTiles;

namespace TremorMod.Content.Items.Placeable.GloomstonePlaceable
{
	public class GloomstoneBrick : ModItem
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
			Item.createTile = ModContent.TileType<GloomstoneBrickTile>();
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Gloomstone Brick");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<GloomstoneBrickWall>(), 4);
			//recipe.SetResult(this, 1);
			recipe.AddTile(17);
			recipe.Register();

			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ModContent.ItemType<Gloomstone>(), 1);
			//recipe.SetResult(this, 1);
			recipe1.AddTile(17);
			recipe1.Register();
		}
	}
}
