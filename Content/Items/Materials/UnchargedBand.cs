using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class UnchargedBand : ModItem
	{
		public override void SetDefaults()
		{
			Item.rare = 11;
			Item.value = 380000;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Uncharged Band");
			//Tooltip.SetDefault("Can be charged with fragments\n" +
			//"Charged band summons a pet");
		}
	}
}