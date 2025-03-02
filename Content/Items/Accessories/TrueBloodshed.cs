using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Accessories
{
	public class TrueBloodshed : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 22;
			Item.height = 44;

			Item.value = 10000;
			Item.rare = 4;
			Item.defense = 6;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("True Bloodshed");
			/* Tooltip.SetDefault("12% increased melee, magic, minion, ranged damage and crit\n" +
"Increases maximum mana and health by 80"); */
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Magic) += 0.12f;
			player.GetDamage(DamageClass.Summon) += 0.12f;
			player.GetDamage(DamageClass.Melee) += 0.12f;
			player.GetDamage(DamageClass.Ranged) += 0.12f;
			player.statManaMax2 += 80;
			player.statLifeMax2 += 80;
			player.GetCritChance(DamageClass.Melee) += 12;
			player.GetCritChance(DamageClass.Magic) += 12;
			player.GetCritChance(DamageClass.Ranged) += 12;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bloodshed>(), 1);
			recipe.AddIngredient(ModContent.ItemType<BrokenHeroAmulet>(), 1);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<GreatAnvilTile>());
			recipe.Register();
		}
	}
}
