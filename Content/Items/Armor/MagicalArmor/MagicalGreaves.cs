using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.MagicalArmor
{
	[AutoloadEquip(EquipType.Legs)]
	public class MagicalGreaves : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 22;
			Item.height = 18;
			Item.value = 250;

			Item.rare = 1;
			Item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Theurgic Greaves");
			// Tooltip.SetDefault("3% increased magic damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Magic) += 0.03f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Silk, 8);
			recipe.AddIngredient(ItemID.LeadBar, 3);
			recipe.AddTile(18);
			recipe.Register();

			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ItemID.Silk, 8);
			recipe1.AddIngredient(ItemID.IronBar, 3);
			recipe1.AddTile(18);
			recipe1.Register();

		}

	}
}
