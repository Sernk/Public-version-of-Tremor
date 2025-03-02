using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Harpy
{
	[AutoloadEquip(EquipType.Legs)]
	public class HarpyLeggings : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = 180;
			Item.rare = 1;
			Item.defense = 4;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Harpy Leggings");
			Tooltip.SetDefault("10% increased movement speed");
		}*/

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.10f;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Silk, 10);
			recipe.AddIngredient(ItemID.Feather, 6);
			//recipe.SetResult(this);
			recipe.AddTile(86);
            recipe.Register();
        }

	}
}
