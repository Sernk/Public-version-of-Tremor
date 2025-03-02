using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Zerokk
{
	[AutoloadEquip(EquipType.Head)]
	public class ZerokkHead : ModItem
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
			// DisplayName.SetDefault("Zerokk's Headgear");
			// Tooltip.SetDefault("'Great for impersonating devs!'");
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<ZerokkBody>() && legs.type == ModContent.ItemType<ZerokkLegs>();
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true; //среднее пульсирование
			player.armorEffectDrawShadowLokis = true; //маленькие тени
		}
	}
}
