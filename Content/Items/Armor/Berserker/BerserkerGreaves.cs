using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Berserker
{
	[AutoloadEquip(EquipType.Legs)]
	public class BerserkerGreaves : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = 500;
			Item.rare = 2;
			Item.defense = 5;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Berserker Greaves");
			Tooltip.SetDefault("4% increased melee damage");
		}*/

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Melee) += 0.04f;
        }
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 16);
            recipe.AddIngredient(ModContent.ItemType<MinotaurHorn>(), 1);
            recipe.AddIngredient(ModContent.ItemType<EarthFragment>(), 8);
			recipe.AddTile(16);
			recipe.Register();
		}
	}
}
