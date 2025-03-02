using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class TheRib : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 28;
			Item.height = 30;
			Item.maxStack = 99;
			Item.value = 100;
			Item.rare = 4;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("The Rib");
			// Tooltip.SetDefault("");
		}

	}
}
