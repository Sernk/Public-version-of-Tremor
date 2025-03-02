using Terraria.ModLoader;

namespace TremorMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Body)]
	public class WarriorChainmail : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 26;
			Item.height = 18;
			Item.value = 1000;
			Item.rare = 2;
			Item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Warrior Chainmail");
			// Tooltip.SetDefault("");
		}

	}
}
