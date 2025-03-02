using Terraria;
using Terraria.ModLoader;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Accessories
{
	public class CthulhuBlood : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 30;
			Item.maxStack = 1;
			Item.value = 255000;
			Item.rare = 8;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Bottled Cthulhu Blood");
			//Tooltip.SetDefault("Increased life regeneration\n" +
			//"Increased alchemical damage and critical strike chance by 25%");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.lifeRegen += 3;
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.25f;
			player.GetModPlayer<MPlayer>().alchemicalCrit += 25;
		}
	}
}
