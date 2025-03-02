using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using TremorMod.Utilities;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Accessories
{
	public class CursedCauldron : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 22;
			Item.height = 44;
			Item.value = 100000;
			Item.rare = 5;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Cursed Cauldron");
			/* Tooltip.SetDefault("15% increased alchemical damage\n" +
			"20% increased alchemical critical strike chance\n" +
			"Alchemic damage confuses enemies"); */
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(8, 4));
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.15f;
			player.AddBuff(ModContent.BuffType<CursedCloudBuff>(), 2);
			player.GetModPlayer<MPlayer>().alchemicalCrit += 20;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<BlackCauldron>(), 1);
			recipe.AddIngredient(ModContent.ItemType<DeathFormula>(), 1);
			recipe.AddTile(114);
			recipe.Register();
		}
	}
}
