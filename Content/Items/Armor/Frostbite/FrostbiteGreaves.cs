using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Frostbite
{
	[AutoloadEquip(EquipType.Legs)]
	public class FrostbiteGreaves : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = 100;
			Item.rare = 1;
			Item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Frostbite Greaves");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IceBlock, 60);
			//recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.Register();
		}
	}
}