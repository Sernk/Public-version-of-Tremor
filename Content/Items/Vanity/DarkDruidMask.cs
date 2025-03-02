using Terraria.ModLoader;

namespace TremorMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class DarkDruidMask : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 36;
			Item.height = 26;
			Item.value = 2500;
			Item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Dark Druid Mask");
			// Tooltip.SetDefault("");
		}

	}
}
