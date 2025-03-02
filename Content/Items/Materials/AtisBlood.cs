using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class AtisBlood : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 99;
			Item.rare = 3;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Atis Blood");
			Tooltip.SetDefault("");
		}*/

	}
}