using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Accessories
{
	public class ArcherGlove : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 24;
			Item.height = 28;
			Item.value = 6000;

			Item.rare = 1;
			Item.accessory = true;
			Item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Archer Glove");
			// Tooltip.SetDefault("5% increased ranged damage");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			player.GetDamage(DamageClass.Ranged) += 0.05f;
		}
	}
}
