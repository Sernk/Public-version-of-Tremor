using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Tiles;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Accessories
{
	public class TheCreator : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 22;
			Item.height = 44;

			Item.value = 10000;
			Item.rare = 4;
			Item.defense = 9;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("The Creator");
			/* Tooltip.SetDefault("15% increased damage and crit\n" +
"Increases maximum mana and health by 100"); */
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Magic) += 0.15f;
			player.GetDamage(DamageClass.Summon) += 0.15f;
			player.GetDamage(DamageClass.Melee) += 0.15f;
			player.GetDamage(DamageClass.Ranged) += 0.15f;
			player.GetDamage(DamageClass.Throwing) += 0.15f;
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.15f;
			player.statManaMax2 += 100;
			player.statLifeMax2 += 100;
			player.GetCritChance(DamageClass.Melee) += 15;
			player.GetCritChance(DamageClass.Magic) += 15;
			player.GetCritChance(DamageClass.Ranged) += 15;
			player.GetCritChance(DamageClass.Throwing) += 15;
			player.GetModPlayer<MPlayer>().alchemicalCrit += 15;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<TrueBloodshed>(), 1);
			recipe.AddIngredient(ModContent.ItemType<TrueSanctifier>(), 1);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<GreatAnvilTile>());
			recipe.Register();

			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ModContent.ItemType<TrueNightsWatch>(), 1);
			recipe1.AddIngredient(ModContent.ItemType<TrueSanctifier>(), 1);
			//recipe.SetResult(this);
			recipe1.AddTile(ModContent.TileType<GreatAnvilTile>());
			recipe1.Register();
		}
	}
}
