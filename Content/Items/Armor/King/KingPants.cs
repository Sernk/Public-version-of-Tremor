using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.King
{
	[AutoloadEquip(EquipType.Legs)]
	public class KingPants : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = 20000;
			Item.rare = 2;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("King Pants");
			//Tooltip.SetDefault("");
		}
	}
}