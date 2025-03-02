using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Guardian
{
	[AutoloadEquip(EquipType.Legs)]
	public class GuardianGreaves : ModItem
	{
		public override void SetDefaults()
		{
			Item.defense = 50;
			Item.width = 22;
			Item.height = 18;
			Item.value = 25000;
			Item.rare = 10;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Guardian Greaves");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<AncientArmorPlate>(), 16);
			recipe.AddIngredient(ModContent.ItemType<Squorb>(), 1);
			//recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.Register();
		}
	}
}
