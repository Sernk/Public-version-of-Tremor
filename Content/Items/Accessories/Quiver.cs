using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Accessories
{
	public class Quiver : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.value = 12000;
			Item.rare = 1;
			Item.accessory = true;
			Item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Quiver");
			//Tooltip.SetDefault("20% chance not to consume ammo");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.ammoCost80 = true;
		}
	}
}