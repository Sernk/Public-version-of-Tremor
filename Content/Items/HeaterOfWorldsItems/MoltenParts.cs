using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.HeaterOfWorldsItems
{
	public class MoltenParts : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 40;
			Item.height = 28;
			Item.maxStack = 99;
			Item.value = 1000;
			Item.rare = 3;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Molten Parts");
			Tooltip.SetDefault("");
		}*/
	}
}
