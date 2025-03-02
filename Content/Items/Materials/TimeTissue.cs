using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class TimeTissue : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 28;
			Item.height = 30;

			Item.maxStack = 99;
			Item.value = 10000;
			Item.rare = 11;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Time Tissue");
			//Tooltip.SetDefault("'It's about time'.");
		}

	}
}
