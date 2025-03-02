using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class HorseMask : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 24;
			Item.rare = 1;
			Item.vanity = true;
        }

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Horse Mask");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Leather, 8);
			//recipe.SetResult(this);
			recipe.AddTile(86);
			recipe.Register();
		}
	}
}