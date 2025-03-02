using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Coral
{
	[AutoloadEquip(EquipType.Body)]
	public class CoralChestplate : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 26;
			Item.height = 18;
			Item.value = 100;
			Item.rare = 1;
			Item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Coral Chestplate");
			// Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Coral, 12);
			recipe.AddIngredient(ItemID.Seashell, 4);
			recipe.AddTile(18);
			recipe.Register();
		}
	}
}
