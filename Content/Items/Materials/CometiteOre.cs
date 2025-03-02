using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Materials
{
	public class CometiteOre : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 12;
			Item.value = 10000;
			Item.height = 12;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.rare = 11;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<CometiteOreTile>();
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cometite Ore");
			Tooltip.SetDefault("'Ore from the depths of space'");
		}*/
	}
}
