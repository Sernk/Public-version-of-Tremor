using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class FaultyRedSteelShield : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 28;
			Item.maxStack = 99;
			Item.value = 50;
			Item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Faulty Red Steel Shield");
			// Tooltip.SetDefault("");
		}
	}
}
