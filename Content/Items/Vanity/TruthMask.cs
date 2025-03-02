using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class TruthMask : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 26;
			Item.height = 28;
			Item.rare = 1;
			Item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Truth Mask");
			// Tooltip.SetDefault("");
		}

	}
}
