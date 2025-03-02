using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class GreenPuzzleFragment : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 24;
			Item.maxStack = 99;
			Item.value = 10000;
			Item.rare = 3;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Green Puzzle Fragment");
			Tooltip.SetDefault("");
		}*/

	}
}
