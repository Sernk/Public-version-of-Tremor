using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Materials
{
	public class SalamanderSkin : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 40;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.value = 150;
			Item.rare = 1;
			Item.createTile = ModContent.TileType<SalamanderSkinTile>();
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Salamander Skin");
			//Tooltip.SetDefault("");
		}
	}
}