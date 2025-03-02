using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class DragonCapsule : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 44;
			Item.height = 44;
			Item.value = 1500;
			Item.maxStack = 999;
			Item.rare = 11;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Dragon Capsule");
			//Tooltip.SetDefault("A capsule of great creature");
		}
	}
}