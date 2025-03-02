using Terraria;
using Terraria.ModLoader;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.DesertExplorer
{
	[AutoloadEquip(EquipType.Body)]
	public class DesertExplorerBreastplate : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 38;
			Item.height = 22;

			Item.value = 16500;
			Item.rare = 8;
			Item.defense = 17;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Desert Explorer Breastplate");
			/* Tooltip.SetDefault("19% increased alchemical damage\n" +
"35% increased throwing damage"); */
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.5f;
			player.GetDamage(DamageClass.Throwing) += 0.35f;
		}
	}
}
