using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Nightingale
{
	[AutoloadEquip(EquipType.Legs)]
	public class NightingaleGreaves : ModItem
	{

		public override void SetDefaults()
		{
			Item.defense = 6;
			Item.width = 22;
			Item.height = 18;
			Item.value = 2500;
			Item.rare = 2;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nightingale Greaves");
			Tooltip.SetDefault("10% increased movement speed");
		}*/

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.10f;
			player.maxRunSpeed += 0.10f;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<PhantomSoul>(), 3);
            //recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.Register();
        }
	}
}
