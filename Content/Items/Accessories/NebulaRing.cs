using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Accessories
{
	public class NebulaRing : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 22;
			Item.value = 250000;
			Item.rare = 8;
			Item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Nebula Ring ");
			//Tooltip.SetDefault("20% increased magic damage\n" +
			//"Increases magic critical strike chance by 15\n" +
			//"Increases maximum mana by 80");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Magic) += 0.2f;
			player.GetCritChance(DamageClass.Magic) += 15;
			player.statManaMax2 += 80;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(3457, 10);
			recipe.AddIngredient(3467, 15);
			recipe.AddIngredient(ModContent.ItemType<Band>());
			//recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.Register();
		}
	}
}
