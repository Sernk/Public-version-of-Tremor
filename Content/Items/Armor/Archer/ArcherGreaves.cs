using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Archer
{
	[AutoloadEquip(EquipType.Legs)]
	public class ArcherGreaves : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 22;
			Item.height = 18;
			Item.value = 1000;
			Item.rare = 2;
			Item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Archer Greaves");
			// Tooltip.SetDefault("");
		}

	}
}
