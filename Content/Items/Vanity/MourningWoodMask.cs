using Terraria.ModLoader;

namespace TremorMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class MourningWoodMask : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 32;
			Item.height = 24;
			Item.rare = 1;
			Item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Mourning Wood Mask");
			// Tooltip.SetDefault("");
		}

	}
}
