using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Sniper
{
	[AutoloadEquip(EquipType.Body)]
	public class SniperBreastplate : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 30;
			Item.height = 22;

			Item.value = 1000000;
			Item.rare = 11;
			Item.defense = 40;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Sniper Breastplate");
			/* Tooltip.SetDefault("20% increased ranged damage\n" +
"20% decreased movement speed"); */
		}

		public override void UpdateEquip(Player player)
		{
            player.GetDamage(DamageClass.Ranged) *= 1.2f;
            player.moveSpeed -= 0.20f;
		}

	}
}
