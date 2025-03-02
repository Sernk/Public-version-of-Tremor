using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class NecroShield : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 30;
			Item.value = 110;
			Item.rare = 0;
			Item.accessory = true;
			Item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Necro Shield");
			//Tooltip.SetDefault("10% increased minion damage\n" +
			//				   "10% increased magic critical strike chance");
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Magic) += 0.1f;
			player.GetDamage(DamageClass.Summon) += 0.1f;
		}
	}
}
