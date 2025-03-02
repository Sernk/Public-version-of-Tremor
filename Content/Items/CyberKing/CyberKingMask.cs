using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.CyberKing
{
	[AutoloadEquip(EquipType.Head)]
	public class CyberKingMask : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 24;
			Item.rare = 1;
			Item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			/*DisplayName.SetDefault("Cyber King Mask");
			Tooltip.SetDefault("");*/
		}
	}
}
