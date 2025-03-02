using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Nightmare
{
	[AutoloadEquip(EquipType.Body)]
	public class NightmareBreastplate : ModItem
	{
		public override void SetDefaults()
		{
			Item.defense = 35;
			Item.width = 22;
			Item.height = 30;
			Item.value = 25000;
			Item.rare = 10;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Nightmare Breastplate");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<NightmareBar>(), 25);
			recipe.AddIngredient(ModContent.ItemType<Phantaplasm>(), 10);
			//recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.Register();
		}
	}
}
