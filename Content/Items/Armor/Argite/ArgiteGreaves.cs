using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;

namespace TremorMod.Content.Items.Armor.Argite
{
	[AutoloadEquip(EquipType.Legs)]
	public class ArgiteGreaves : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = 15000;
			Item.rare = 3;
			Item.defense = 6;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Argite Greaves");
			Tooltip.SetDefault("10% increased movement speed");
		}*/

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.1f;
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ArgiteBar>(), 18);
            //recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}
