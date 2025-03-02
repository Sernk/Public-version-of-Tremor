using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Archer
{
	[AutoloadEquip(EquipType.Head)]
	public class ArcherHelmet : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 26;
			Item.height = 22;
			Item.value = 1000;
			Item.rare = 2;
			Item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Archer Helmet");
			// Tooltip.SetDefault("");
        }

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<ArcherChainmail>() && legs.type == ModContent.ItemType<ArcherGreaves>();
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}
	}
}
