using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class PusheenMask : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 20;
			Item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Pusheen Mask");
			//Tooltip.SetDefault("'Meow?'");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Silk, 15);
			//recipe.SetResult(this);
			recipe.AddTile(86);
			recipe.Register();
		}
	}
}