using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;

namespace TremorMod.Content.Items.Armor.Chaos
{
	[AutoloadEquip(EquipType.Legs)]
	public class ChaosGreaves : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = 6000;
			Item.rare = 5;
			Item.defense = 11;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chaos Greaves");
			Tooltip.SetDefault("Increased life max by 25\n" +
			"Increased wing time");
		}*/

		public override void UpdateEquip(Player player)
		{
			player.wingTime += 0.15f;
			player.statLifeMax2 += 25;
		}

		public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ChaosBar>(), 17);
            //recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.Register();
        }
    }
}
