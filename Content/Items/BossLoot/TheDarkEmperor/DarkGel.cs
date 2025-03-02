using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.BossLoot.TheDarkEmperor
{
	public class DarkGel : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 30;
			Item.maxStack = 99;
			Item.value = 1000;
			Item.rare = 11;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Dark Gel");
			//Tooltip.SetDefault("");
		}
	}
}