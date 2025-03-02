using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.EvilCornItems
{
	[AutoloadEquip(EquipType.Head)]
	public class EvilCornMask : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 22;
			Item.rare = 1;
			Item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Evil Corn Mask");
			//Tooltip.SetDefault("");
		}
	}
}