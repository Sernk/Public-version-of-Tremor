using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Accessories
{
	public class HeartofAtis : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 44;
			Item.value = 1200;
			Item.rare = 2;
			Item.accessory = true;
			Item.defense = 3;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heart of Atis");
			Tooltip.SetDefault("Increases life regeneration");
		}*/

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.lifeRegen += 1;
		}
	}
}
