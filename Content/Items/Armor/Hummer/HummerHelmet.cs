using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Hummer
{
	[AutoloadEquip(EquipType.Head)]
	public class HummerHelmet : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 26;
			Item.rare = 9;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Hummer's Helmet");
			//Tooltip.SetDefault("'Great for impersonating devs!'");
		}
	}
}