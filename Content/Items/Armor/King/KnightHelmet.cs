using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.King
{
	[AutoloadEquip(EquipType.Head)]
	public class KnightHelmet : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 24;
			Item.value = 2500;
			Item.rare = 1;
			Item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Knight Helmet");
			//Tooltip.SetDefault("");
		}
	}
}