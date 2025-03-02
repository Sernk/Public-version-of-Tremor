using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class CursedCloth : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 99;
			Item.rare = 4;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Cursed Cloth");
			// Tooltip.SetDefault("");
		}
	}
}
