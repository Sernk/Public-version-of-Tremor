using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Zerokk
{
	[AutoloadEquip(EquipType.Legs)]
	public class ZerokkLegs : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 18;
			Item.height = 18;
			Item.value = 30000;

			Item.rare = 9;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Zerokk's Leggings");
			// Tooltip.SetDefault("'Great for impersonating devs!'");
		}

	}
}
