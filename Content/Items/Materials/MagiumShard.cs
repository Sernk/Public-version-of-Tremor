using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class MagiumShard : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 24;
			Item.maxStack = 99;
			Item.value = 120;
			Item.rare = 5;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Magium Shard");
			//Tooltip.SetDefault("");
		}
	}
}