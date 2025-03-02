using Terraria.ModLoader;

namespace TremorMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Body)]
	public class PlagueRobe : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 26;
			Item.height = 24;

			Item.rare = 2;
			Item.value = 10000;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Plague Robe");
			// Tooltip.SetDefault("'HEE HEE HEE'");
		}

	}
}
