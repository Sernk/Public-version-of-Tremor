using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Heaven
{
	[AutoloadEquip(EquipType.Legs)]
	public class HeavenLeggings : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 22;
			Item.height = 18;
			Item.value = 6000;

			Item.rare = 3;
			Item.defense = 5;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Heaven Leggings");
			// Tooltip.SetDefault("15% decreased movement speed");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed -= 0.15f;
		}
	}
}
