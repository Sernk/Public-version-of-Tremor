using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Accessories
{
	public class StardustRing : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 30;
			Item.height = 24;
			Item.value = 250000;
			Item.rare = 8;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Stardust Ring ");
			/* Tooltip.SetDefault("20% increased minion damage\n" +
"Increases your maximum number of minions"); */
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.GetDamage(DamageClass.Summon) += 0.2f;
            player.maxMinions += 2;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(3459, 10);
			recipe.AddIngredient(3467, 15);
			recipe.AddIngredient(ModContent.ItemType<Band>());
			//recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.Register();
		}
	}
}
