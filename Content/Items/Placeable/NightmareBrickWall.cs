using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Placeable
{
	public class NightmareBrickWall : ModItem
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
			Item.rare = 11;
			Item.consumable = true;
			Item.createWall = ModContent.WallType<NightmareBrickWallTile>();
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Nightmare Brick Wall");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(4);
			recipe.AddIngredient(ModContent.ItemType<NightmareBrick>(), 1);
			recipe.AddTile(17);
			recipe.Register();
		}
	}
}
