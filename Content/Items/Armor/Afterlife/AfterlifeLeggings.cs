using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Afterlife
{
	[AutoloadEquip(EquipType.Legs)]
	public class AfterlifeLeggings : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 38;
			Item.height = 22;
			Item.value = 10000;
			Item.rare = 6;
			Item.defense = 9;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Afterlife Leggings");
			Tooltip.SetDefault("Higher jump height\n" +
			"Increases movement speed");
		}*/

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.25f;
			player.jumpBoost = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SkullTeeth>(), 8);
            recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 16);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}

	}
}
