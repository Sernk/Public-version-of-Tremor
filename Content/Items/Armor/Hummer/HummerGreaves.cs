using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Hummer
{
	[AutoloadEquip(EquipType.Legs)]
	public class HummerGreaves : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.rare = 9;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Hummer's Greaves");
			//Tooltip.SetDefault("'Great for impersonating devs!'");
		}		
	}
}