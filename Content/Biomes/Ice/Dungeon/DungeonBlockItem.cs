using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Biomes.Ice.Dungeon
{
	public class DungeonBlockItem : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 12;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<DungeonBlock>();
			ItemID.Sets.ExtractinatorMode[Item.type] = Item.type;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Brick");
			Tooltip.SetDefault("");
		}*/

		public override void AddRecipes()
		{
			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ModContent.ItemType<IceBlockB>(), 2);
			//recipe.SetResult(this);
			recipe1.AddTile(18);
			recipe1.Register();

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ModContent.ItemType<DungeonWallItem>(), 4);
			//recipe.SetResult(this);
			recipe2.AddTile(18);
			recipe2.Register();
		}
	}
}
