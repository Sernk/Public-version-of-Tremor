using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Biomes.Ice.Items.Furniture
{
	public class IceChestItem : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 50;
			Item.height = 26;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.value = 150;
			Item.createTile = ModContent.TileType<IceChest>();
			ItemID.Sets.ExtractinatorMode[Item.type] = Item.type;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frostbite Chest");
			Tooltip.SetDefault("");
		}*/
	}
}
