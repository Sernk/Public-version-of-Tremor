using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Enchanted
{
	[AutoloadEquip(EquipType.Legs)]
	public class EnchantedGreaves : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = 2;
			Item.defense = 5;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Enchanted Greaves");
			//Tooltip.SetDefault("Increases maximum mana by 20\n" +
			//"Increases maximum health by 15");
		}

		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += 20;
			player.statLifeMax2 += 15;
		}

	}
}