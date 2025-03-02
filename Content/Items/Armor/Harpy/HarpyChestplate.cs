using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Harpy
{
	[AutoloadEquip(EquipType.Body)]
	public class HarpyChestplate : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 18;
			Item.value = 100;
			Item.rare = 2;
			Item.defense = 5;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Harpy Chestplate");
			Tooltip.SetDefault("Increases jump height");
		}*/

		public override void UpdateEquip(Player player)
		{
			player.jumpBoost = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Silk, 10);
			recipe.AddIngredient(ItemID.Feather, 13);
			//recipe.SetResult(this);
			recipe.AddTile(86);
			recipe.Register();
		}
	}
}
