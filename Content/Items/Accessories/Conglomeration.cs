using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.BossLoot.TheDarkEmperor;

namespace TremorMod.Content.Items.Accessories
{
	public class Conglomeration : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 44;
			Item.value = 250000;
			Item.rare = 11;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Conglomeration");
			//Tooltip.SetDefault("Prolonged after hit invincibility\n" +
			//"Greatly increased life regeneration\n" +
			//"Increases maximum life by 140");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.moveSpeed -= 0.2f;
			player.longInvince = true;
			player.lifeRegen += 45;
			player.statLifeMax2 += 140;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SwampClump>());
			recipe.AddIngredient(ModContent.ItemType<ExtraterrestrialRubies>());
			recipe.AddIngredient(ModContent.ItemType<DelightfulClump>());
			//recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.Register();
		}
	}
}
