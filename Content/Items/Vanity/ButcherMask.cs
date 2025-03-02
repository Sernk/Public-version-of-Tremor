using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class ButcherMask : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 20;
			Item.value = 20000;
			Item.rare = 0;
			Item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Butcher Mask");
			//Tooltip.SetDefault("");
		}
	}
}