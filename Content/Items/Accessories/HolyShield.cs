using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class HolyShield : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 26;
			Item.value = 12000;
			Item.rare = 7;
			Item.accessory = true;
			Item.defense = 6;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Holy Shield");
			//Tooltip.SetDefault("Prolonged after hit invincibility");
		}

		public override void UpdateEquip(Player player)
		{
			player.longInvince = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.PaladinsShield, 1);
			recipe.AddIngredient(ItemID.CrossNecklace, 1);
			//recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.Register();
		}
	}
}
