using Terraria;
using Terraria.ModLoader;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Accessories
{
	public class GoldenStar : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 36;
			Item.height = 38;
			Item.value = 12500;
			Item.rare = 9;
			Item.expert = true;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Golden Star");
			//Tooltip.SetDefault("The less health, the more alchemical damage\n" +
			//"'Rare alchemical artifact'");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			if (player.statLife < 50)
			{
				player.GetModPlayer<MPlayer>().alchemicalDamage += 0.35f;
			}
			if (player.statLife < 100)
			{
				player.GetModPlayer<MPlayer>().alchemicalDamage += 0.25f;
			}
			if (player.statLife < 200)
			{
				player.GetModPlayer<MPlayer>().alchemicalDamage += 0.15f;
			}
			if (player.statLife < 300)
			{
				player.GetModPlayer<MPlayer>().alchemicalDamage += 0.05f;
			}
		}

	}
}
