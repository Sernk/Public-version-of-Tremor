using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class GiantShell : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 24;
			Item.maxStack = 99;
			Item.value = 25000;
			Item.rare = 8;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Giant Shell");
			//Tooltip.SetDefault("");
		}
	}
}