using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Accessories
{
	public class SwampClump : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 44;
			Item.value = 100;
			Item.rare = 7;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Swamp Clump");
			//Tooltip.SetDefault("Greatly reduces movement speed\n" +
			//"Prolonged after hit invicibility\n" +
			//"Greatly increases life regeneration");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.moveSpeed -= 0.4f;
			player.longInvince = true;
			player.lifeRegen += 5;
		}
	}
}