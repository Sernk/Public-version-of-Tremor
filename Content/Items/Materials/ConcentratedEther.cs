using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class ConcentratedEther : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 24;
			Item.maxStack = 99;
			Item.value = 15000;
			Item.rare = 9;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Concentrated Ether");
			//Tooltip.SetDefault("");
		}
	}
}
