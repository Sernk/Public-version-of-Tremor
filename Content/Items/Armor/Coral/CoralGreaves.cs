using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Coral
{
	[AutoloadEquip(EquipType.Legs)]
	public class CoralGreaves : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 22;
			Item.height = 18;
			Item.value = 180;
			Item.rare = 1;
			Item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Coral Greaves");
			// Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Coral, 10);
			recipe.AddIngredient(ItemID.Starfish, 6);
			recipe.AddTile(18);
			recipe.Register();
		}

	}
}
