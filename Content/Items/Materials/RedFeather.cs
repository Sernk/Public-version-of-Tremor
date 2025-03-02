using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class RedFeather : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 24;
			Item.maxStack = 99;
			Item.value = 3000;
			Item.rare = 4;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Red Feather");
			//Tooltip.SetDefault("");
		}
	}
}