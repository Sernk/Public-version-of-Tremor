using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Leather
{
	[AutoloadEquip(EquipType.Legs)]
	public class LeatherGreaves : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 20;
			Item.value = 200;
			Item.rare = 1;
			Item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Leather Greaves");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Leather, 15);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();

			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ItemID.Leather, 15);
			recipe1.AddTile(TileID.HeavyWorkBench);
			recipe1.Register();
		}
	}
}
