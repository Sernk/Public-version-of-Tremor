using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.CraftingStations
{
	public class BlastFurnace : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 14;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.value = 150;
			Item.createTile = ModContent.TileType<BlastFurnaceTile>();
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blast Furnace");
			Tooltip.SetDefault("Used to craft alloys");
		}*/

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.GrayBrick, 25);
			recipe.AddIngredient(ModContent.ItemType<Charcoal>(), 15);
			recipe.AddIngredient(ItemID.LavaBucket, 1);
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
