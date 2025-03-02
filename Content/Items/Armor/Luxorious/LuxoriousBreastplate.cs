using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;

namespace TremorMod.Content.Items.Armor.Luxorious
{
	[AutoloadEquip(EquipType.Body)]
	public class LuxoriousBreastplate : ModItem
	{
		public override void SetDefaults()
		{
			Item.defense = 20;
			Item.width = 22;
			Item.height = 30;
			Item.value = 2500;
			Item.rare = 8;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Luxorious Breastplate");
			//Tooltip.SetDefault("12% increased mining speed");
		}

		public override void UpdateEquip(Player player)
		{
			player.pickSpeed -= 0.12f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<EvershinyBar>(), 25);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
