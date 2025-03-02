using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class DarknessCloth : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 24;
			Item.maxStack = 999;
			Item.value = 600;
			Item.rare = 7;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Darkness Cloth");
			//Tooltip.SetDefault("");
		}
	}
}