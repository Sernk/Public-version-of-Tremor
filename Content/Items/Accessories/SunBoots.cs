using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Accessories
{
	public class SunBoots : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 26;
			Item.height = 28;
			Item.value = 00150000;
			Item.rare = 11;

			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Paradox Boots");
			/* Tooltip.SetDefault("Allows you to control gravity\n" +
"Increases speed and regeneration, increases maximum health by 50"); */
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.5f;
			player.lifeRegen += 2;
			player.statLifeMax2 += 50;
			player.accRunSpeed = 10f;
			player.gravControl = true;
		}
	}
}
