using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.BossLoot.TikiTotem
{
	[AutoloadEquip(EquipType.Head)]
	public class HappyTotemMask : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 36;
			Item.height = 24;
			Item.rare = 1;
			Item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Happy Totem Mask");
			//Tooltip.SetDefault("");
		}
	}
}