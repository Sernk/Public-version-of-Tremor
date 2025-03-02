using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class TearsofDeath : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 28;
			Item.maxStack = 99;
			Item.value = 100;
			Item.rare = 3;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Tears of Death");
			//Tooltip.SetDefault("Unstable ingredient");
		}
	}
}