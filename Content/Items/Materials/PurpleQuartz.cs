using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class PurpleQuartz : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 24;
			Item.maxStack = 99;
			Item.value = 12000;
			Item.rare = 9;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Purple Quartz");
			//Tooltip.SetDefault("");
		}
	}
}