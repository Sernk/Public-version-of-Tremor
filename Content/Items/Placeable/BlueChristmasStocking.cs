using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Placeable
{
	public class BlueChristmasStocking : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 26;
			Item.maxStack = 99;
			Item.rare = 1;
			Item.createTile = ModContent.TileType<BlueChristmasStockingTile>();
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.value = 100;
			Item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Blue Christmas Stocking");
			//Tooltip.SetDefault("");
		}
	}
}