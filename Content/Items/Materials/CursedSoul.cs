using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class CursedSoul : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 28;
			Item.maxStack = 99;
			Item.value = 1000;
			Item.rare = 4;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Cursed Soul");
			//Tooltip.SetDefault("");
		}
	}
}