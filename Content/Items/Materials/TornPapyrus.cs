using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class TornPapyrus : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 999;
			Item.rare = 2;
			Item.value = 6000;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Torn Papyrus");
			//Tooltip.SetDefault("");
		}
	}
}
