using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Zerokk
{
	[AutoloadEquip(EquipType.Body)]
	public class ZerokkBody : ModItem
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
			// DisplayName.SetDefault("Zerokk's Bodyplate");
			// Tooltip.SetDefault("'Great for impersonating devs!'");
		}

		public override void UpdateEquip(Player player)
		{
			if (player.name == "Error 404")
			{
				player.lifeRegen = +999;
			}
		}
	}
}
