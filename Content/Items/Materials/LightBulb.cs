using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class LightBulb : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 14;
			Item.height = 22;
			Item.maxStack = 999;
			Item.rare = 3;
			Item.value = Item.buyPrice(0, 0, 10, 0);
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Light Bulb");
			//Tooltip.SetDefault("");
		}
	}
}