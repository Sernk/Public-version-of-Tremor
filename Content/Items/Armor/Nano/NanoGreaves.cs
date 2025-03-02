using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;

namespace TremorMod.Content.Items.Armor.Nano
{
	[AutoloadEquip(EquipType.Legs)]
	public class NanoGreaves : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = 6000;
			Item.rare = 6;
			Item.defense = 12;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nano Greaves");
			Tooltip.SetDefault("20% increased movement speed");
		}*/

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.20f;
		}
		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<NanoBar>(), 15);
            //recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.Register();
        }
	}
}
