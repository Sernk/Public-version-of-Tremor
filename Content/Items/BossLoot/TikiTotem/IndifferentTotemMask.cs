using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.BossLoot.TikiTotem
{
	[AutoloadEquip(EquipType.Head)]
	public class IndifferentTotemMask : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 24;
			Item.rare = 1;
			Item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Indifferent Totem Mask");
			//Tooltip.SetDefault("");
		}
	}
}