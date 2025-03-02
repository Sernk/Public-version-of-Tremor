using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class EssenseofJungle : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 14;
			Item.height = 22;
			Item.maxStack = 99;
			Item.rare = 8;
			Item.value = Item.buyPrice(0, 5, 0, 0);

		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Essence of Jungle");
			//Tooltip.SetDefault("'Plants fill you with determination.'");
		}
	}
}