using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Accessories
{
	public class SecondHand : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 26;
			Item.height = 20;
			Item.alpha = 100;
			Item.value = 110000;
			Item.rare = 10;

			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Second Hand");
			// Tooltip.SetDefault("Increases tile and wall placement range");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			Player.tileRangeX += 10;
			Player.tileRangeY += 10;
		}

	}
}
