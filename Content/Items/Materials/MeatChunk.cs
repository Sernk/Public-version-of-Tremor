using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class MeatChunk : ModItem
	{
		public override void SetDefaults()
		{
			Item.rare = 3;
			Item.maxStack = 30;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Meat Chunk");
			//Tooltip.SetDefault("");
		}
	}
}