using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class PyramidHat : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 24;
			Item.rare = 2;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Pyramid Hat");
			//Tooltip.SetDefault("");
		}
	}
}