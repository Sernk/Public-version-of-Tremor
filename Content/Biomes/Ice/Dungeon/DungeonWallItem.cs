using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Biomes.Ice.Dungeon
{
	public class DungeonWallItem : ModItem
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
			Item.consumable = true;
			Item.createWall = ModContent.WallType<DungeonWall>();
			ItemID.Sets.ExtractinatorMode[Item.type] = Item.type;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Brick Wall");
			Tooltip.SetDefault("");
		}*/

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<DungeonBlockItem>());
			//recipe.SetResult(this, 4);
			recipe.AddTile(18);
			recipe.Register();
		}
	}
}
