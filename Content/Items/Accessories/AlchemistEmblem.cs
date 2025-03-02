using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Accessories
{
	public class AlchemistEmblem : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 28;
			Item.height = 28;
			Item.value = 20000;
			Item.rare = 4;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Alchemist Emblem");
			// Tooltip.SetDefault("15% increased alchemical damage");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.15f;
		}
	}
}
