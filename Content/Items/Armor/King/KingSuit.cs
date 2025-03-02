using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.King
{
	[AutoloadEquip(EquipType.Body)]
	public class KingSuit : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 20;
			Item.value = 20000;
			Item.rare = 2;
			Item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("King Suit");
			//Tooltip.SetDefault("");
		}
	}
}