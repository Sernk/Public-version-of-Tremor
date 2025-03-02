using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class SpinalMask : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 22;

			Item.height = 26;
			Item.rare = 9;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Spinal111 Mask");
			// Tooltip.SetDefault("'Great for impersonating YouTubers!'");
		}

	}
}
