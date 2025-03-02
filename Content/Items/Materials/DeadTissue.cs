using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class DeadTissue : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 24;
			Item.maxStack = 99;
			Item.value = 12000;
			Item.rare = 10;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Dead Tissue");
			//Tooltip.SetDefault("");
		}
	}
}