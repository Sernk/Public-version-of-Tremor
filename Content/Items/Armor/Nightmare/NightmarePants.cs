using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Nightmare
{
	[AutoloadEquip(EquipType.Legs)]
	public class NightmarePants : ModItem
	{
		public override void SetDefaults()
		{
			Item.defense = 22;
			Item.width = 22;
			Item.height = 18;
			Item.value = 25000;
			Item.rare = 10;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Nightmare Pants");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<NightmareBar>(), 20);
			recipe.AddIngredient(ModContent.ItemType<PurpleQuartz>(), 8);
			//recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.Register();
		}
	}
}
