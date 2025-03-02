using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class StoneDice : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 24;
			Item.maxStack = 999;
			Item.value = 1000;
			Item.rare = 3;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Stone Dice");
			//Tooltip.SetDefault("");
		}
	}
}