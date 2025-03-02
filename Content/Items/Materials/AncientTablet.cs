using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class AncientTablet : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 34;
			Item.height = 40;
			Item.maxStack = 99;
			Item.value = 10000;
			Item.rare = 10;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ancient Tablet");
			// Tooltip.SetDefault("");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(8, 4));
		}
	}
}
