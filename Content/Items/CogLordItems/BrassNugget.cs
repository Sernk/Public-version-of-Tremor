using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.CogLordItems
{
	public class BrassNugget : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 99;
			Item.value = 300;
			Item.rare = 5;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brass Nugget");
			Tooltip.SetDefault("");
		}*/

	}
}
