using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Tiles;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Placeable
{
	public class Doombrick : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 12;
			Item.height = 12;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.value = 2000;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.rare = 7;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<DoombrickTile>();
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Doombrick");
			// Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<DoombrickWall>(), 4);
			recipe.AddTile(17);
			recipe.Register();

			Recipe recipe1 = CreateRecipe(50);
			recipe1.AddIngredient(ModContent.ItemType<Doomstone>(), 1);
			recipe1.AddIngredient(ItemID.StoneBlock, 50);
			recipe1.AddTile(17);
			recipe1.Register();
		}
	}
}
