using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.CraftingStations
{
	public class MineralTransmutator : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 46;
			Item.height = 46;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.value = 150;
			Item.createTile = ModContent.TileType<MineralTransmutatorTile>();
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Mineral Transmutator");
			//Tooltip.SetDefault("Allows to transform pre-hardmode metals to their alternatives");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Extractinator, 1);
			recipe.AddIngredient(ItemID.SilverOre, 15);
			recipe.AddIngredient(ItemID.TungstenOre, 15);
			recipe.AddIngredient(ItemID.Diamond, 6);
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
