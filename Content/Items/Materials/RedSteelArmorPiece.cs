using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class RedSteelArmorPiece : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 24;
			Item.height = 18;
			Item.maxStack = 99;
			Item.value = 50;
			Item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Red Steel Armor Piece");
			// Tooltip.SetDefault("");
		}

	}
}
