using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class AlchemasterMask : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 26;
			Item.height = 24;
			Item.rare = 1;
			Item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Alchemaster Mask");
			// Tooltip.SetDefault("");
		}

	}
}
