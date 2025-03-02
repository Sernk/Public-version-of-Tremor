using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Frostbite
{
	[AutoloadEquip(EquipType.Body)]
	public class FrostbiteChestplate : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 18;
			Item.value = 600;
			Item.rare = 1;
			Item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Frostbite Chestplate");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IceBlock, 75);
			//recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.Register();
		}
	}
}