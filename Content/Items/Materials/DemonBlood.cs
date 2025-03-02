using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class DemonBlood : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 26;
			Item.maxStack = 99;
			Item.value = 100;
			Item.rare = 4;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Demon Blood");
			//Tooltip.SetDefault("");
		}
	}
}