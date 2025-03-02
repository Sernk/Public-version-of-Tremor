using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class ParadoxElement : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 46;
			Item.height = 46;
			Item.value = 600;
			Item.rare = 11;

			Item.maxStack = 999;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Paradox Element");
			// Tooltip.SetDefault("'Element of paradox warriors'");
		}

	}
}
