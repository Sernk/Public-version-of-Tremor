using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class Phantaplasm : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 36;
			Item.height = 52;
			Item.maxStack = 99;
			Item.value = 15000;
			Item.rare = 10;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alphaplasm");
			Tooltip.SetDefault("");
		}*/
	}
}
