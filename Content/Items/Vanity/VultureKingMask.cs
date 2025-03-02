using Terraria.ModLoader;

namespace TremorMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class VultureKingMask : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 30;
			Item.height = 22;
			Item.value = 20000;
			Item.rare = 0;
			Item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Rukh Mask");
			// Tooltip.SetDefault("");
		}

	}
}
