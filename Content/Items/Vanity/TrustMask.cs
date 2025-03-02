using Terraria.ModLoader;

namespace TremorMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class TrustMask : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 32;
			Item.rare = 1;
			Item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Doom Mask");
			// Tooltip.SetDefault("");
		}

	}
}
