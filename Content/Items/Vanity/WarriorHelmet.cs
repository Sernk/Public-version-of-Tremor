using Terraria.ModLoader;

namespace TremorMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class WarriorHelmet : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 26;
			Item.height = 22;
			Item.value = 1000;
			Item.rare = 2;
			Item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Warrior Helmet");
			// Tooltip.SetDefault("");
		}

	}
}
