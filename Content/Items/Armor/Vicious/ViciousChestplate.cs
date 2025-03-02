using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Vicious
{
	[AutoloadEquip(EquipType.Body)]
	public class ViciousChestplate : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 38;
			Item.height = 22;

			Item.value = 30000;
			Item.rare = 1;
			Item.defense = 5;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Vicious Chestplate");
			/* Tooltip.SetDefault("8% increased minion damage\n" +
"Increases your max number of minions"); */
		}

		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 1;
			player.GetDamage(DamageClass.Summon) += 0.08f;
		}

	}
}
