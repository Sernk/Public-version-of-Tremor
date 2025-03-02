using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Accessories
{
	public class VortexRing : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 28;
			Item.height = 20;
			Item.value = 250000;
			Item.rare = 8;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Vortex Ring ");
			/* Tooltip.SetDefault("20% increased ranged damage\n" +
"Increases ranged critical strike chance by 15\n" +
"25% chance not to consume ammo"); */
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Ranged) += 0.2f;
			player.GetCritChance(DamageClass.Ranged) += 15;
			player.ammoCost75 = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(3456, 10);
			recipe.AddIngredient(3467, 15);
			recipe.AddIngredient(ModContent.ItemType<Band>());
			//recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.Register();
		}
	}
}
