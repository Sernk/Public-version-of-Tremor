using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class CopperShield : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 26;
			Item.value = 110;
			Item.rare = 0;
			Item.accessory = true;
			Item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Copper Shield");
			//Tooltip.SetDefault("");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed -= 0.10f;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CopperBar, 15);
			//recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.Register();
		}
	}
}
