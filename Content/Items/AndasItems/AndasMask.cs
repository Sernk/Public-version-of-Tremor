using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.AndasItems
{
	[AutoloadEquip(EquipType.Head)]
	public class AndasMask : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 20;
			Item.height = 24;
			Item.rare = 1;
			Item.vanity = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Andas Mask");
			Tooltip.SetDefault("");
		}*/
	}
}
