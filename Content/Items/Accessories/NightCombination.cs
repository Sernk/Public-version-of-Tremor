using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Accessories
{
	public class NightCombination : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.value = 50000;
			Item.rare = 1;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Nightly Combination");
			//Tooltip.SetDefault("Increases life regeneration, melee damage\n" +
			//"Makes you glow during night");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			if (!Main.dayTime)
			{
				player.AddBuff(11, 10);
				player.AddBuff(12, 10);
				player.lifeRegen += 1;
				player.GetDamage(DamageClass.Generic) += 0.1f;
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bloomstone>());
			recipe.AddIngredient(ModContent.ItemType<DragonGem>());
			recipe.AddIngredient(ModContent.ItemType<TwilightHorns>());
			//recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.Register();
		}
	}
}
