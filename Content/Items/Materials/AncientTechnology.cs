using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class AncientTechnology : ModItem
	{
		public override void SetDefaults()
		{
			Item.height = 16;
			Item.maxStack = 20;
			Item.value = 1000000;
			Item.rare = 8;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Ancient Technology");
			//Tooltip.SetDefault("");
		}
	}
}