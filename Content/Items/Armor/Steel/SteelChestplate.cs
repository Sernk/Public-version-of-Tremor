using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Armor.Leather;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Steel
{
	[AutoloadEquip(EquipType.Body)]
	public class SteelChestplate : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 26;
			Item.height = 18;

			Item.value = 600;
			Item.rare = 1;
			Item.defense = 5;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Steel Chestplate");
			// Tooltip.SetDefault("3% increased ranged critical strike chance");
		}

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Ranged) += 3;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 23);
			recipe.AddIngredient(ModContent.ItemType<LeatherShirt>(), 1);
			recipe.AddTile(16);
			recipe.Register();
		}
	}
}
