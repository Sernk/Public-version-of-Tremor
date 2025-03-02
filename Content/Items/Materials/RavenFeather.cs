using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class RavenFeather : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.rare = 4;
			Item.maxStack = 999;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Raven Feather");
			//Tooltip.SetDefault("");
		}
	}
}