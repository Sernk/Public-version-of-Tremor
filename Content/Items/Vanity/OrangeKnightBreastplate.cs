using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Body)]
	public class OrangeKnightBreastplate : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 24;
			Item.value = 10000;
			Item.rare = 2;
			Item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Orange Knight Breastplate");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<GrayKnightBreastplate>(), 3);
			recipe.AddIngredient(ItemID.Amber, 1);
			//recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.Register();
		}
	}
}
