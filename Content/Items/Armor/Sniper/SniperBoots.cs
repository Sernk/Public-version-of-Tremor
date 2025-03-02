using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Sniper
{
	[AutoloadEquip(EquipType.Legs)]
	public class SniperBoots : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 22;
			Item.height = 18;
			Item.value = 1000000;

			Item.rare = 11;
			Item.defense = 32;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Sniper Boots");
			/* Tooltip.SetDefault("15% increased ranged damage\n" +
"20% decreased movement speed"); */
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Ranged) *= 1.15f;
			player.moveSpeed -= 0.20f;
		}
	}
}