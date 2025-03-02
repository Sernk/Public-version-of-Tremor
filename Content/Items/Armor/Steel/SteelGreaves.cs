using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Armor.Leather;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Steel
{
	[AutoloadEquip(EquipType.Legs)]
	public class SteelGreaves : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 22;
			Item.height = 18;
			Item.value = 500;

			Item.rare = 1;
			Item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Steel Greaves");
			// Tooltip.SetDefault("3% increased magic critical strike chance");
		}

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Magic) += 3;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 15);
			recipe.AddIngredient(ModContent.ItemType<LeatherGreaves>(), 1);
			recipe.AddTile(16);
			recipe.Register();
		}
	}
}
