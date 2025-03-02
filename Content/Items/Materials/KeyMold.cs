using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class KeyMold : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 40;
			Item.maxStack = 99;
			Item.value = 300000;
			Item.rare = 5;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Key Mold");
			//Tooltip.SetDefault("");
		}
	}
}