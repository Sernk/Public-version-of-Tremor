using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Biomes.Ice
{
	public class IceWallW : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 12;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.autoReuse = false;
			Item.useAnimation = 15;
			Item.useTime = 7;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.createWall = ModContent.WallType<IceWall>();
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Everfrost Wall");
			//Tooltip.SetDefault("");
			ItemID.Sets.ExtractinatorMode[Item.type] = Item.type;
		}

	}
}
