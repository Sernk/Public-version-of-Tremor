using Terraria.ModLoader;

namespace TremorMod.Content.Items
{
	public class SuspiciousLookingPresent : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 24;
			Item.height = 22;
			Item.maxStack = 1;
			Item.value = 10000;

			Item.rare = 3;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Suspicious Looking Present");
			// Tooltip.SetDefault("Allows the Elf to move in");
		}

	}
}
