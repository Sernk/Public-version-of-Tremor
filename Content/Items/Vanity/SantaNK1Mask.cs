using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class SantaNK1Mask : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 34;
			Item.rare = 1;
			Item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Santa-NK1 Mask");
			//Tooltip.SetDefault("");
		}
	}
}