using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Tiles;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Placeable
{
	public class DoombrickWall : ModItem
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
			Item.rare = 7;
			Item.consumable = true;
			Item.createWall = ModContent.WallType<DoombrickWallTile>();
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Doombrick Wall");
			// Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(4);
			recipe.AddIngredient(ModContent.ItemType<Doombrick>(), 1);
			recipe.AddTile(17);
			recipe.Register();
		}
	}
}
