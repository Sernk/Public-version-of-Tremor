using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class ChargedCrystal : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 14;
			Item.height = 22;
			Item.maxStack = 999;
			Item.rare = 11;
			Item.value = Item.buyPrice(0, 1, 0, 0);
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Charged Crystal");
			Tooltip.SetDefault("");
		}*/
	}
}
