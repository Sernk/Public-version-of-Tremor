using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Archer
{
	[AutoloadEquip(EquipType.Body)]
	public class ArcherChainmail : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 18;
			Item.value = 1000;
			Item.rare = 2;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Archer Chainmail");
			// Tooltip.SetDefault("");
		}

	}
}
