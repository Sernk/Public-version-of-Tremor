using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Biomes.Ice
{
	public class IceKey : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 999;
			Item.value = 100000;
			Item.rare = 3;
			Item.consumable = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ice Key");
			Tooltip.SetDefault("Opens the Frozen Chest once");
		}*/
	}
}
