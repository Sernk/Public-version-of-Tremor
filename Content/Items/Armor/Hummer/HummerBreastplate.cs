using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Hummer
{
	[AutoloadEquip(EquipType.Body)]
	public class HummerBreastplate : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 18;
			Item.rare = 9;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Hummer's Breastplate");
			//Tooltip.SetDefault("'Great for impersonating devs!'");
		}

		public override void UpdateEquip(Player player)
		{
			if (player.name == "Hummer")
			{
				player.lifeRegen = +999;
			}
		}
	}
}
