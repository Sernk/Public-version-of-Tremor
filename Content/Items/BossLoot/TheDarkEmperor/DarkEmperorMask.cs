using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.BossLoot.TheDarkEmperor
{
	[AutoloadEquip(EquipType.Head)]
	public class DarkEmperorMask : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 20;
			Item.height = 24;
			Item.rare = 1;
			Item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Dark Emperor Mask");
			//Tooltip.SetDefault("");
		}
	}
}