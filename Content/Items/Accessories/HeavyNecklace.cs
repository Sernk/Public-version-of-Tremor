using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Accessories
{
	public class HeavyNecklace : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 34;
			Item.value = 100000;
			Item.rare = 2;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Heavy Necklace");
			//Tooltip.SetDefault("5% increased damage");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Generic) += 0.05f;
		}
	}
}
