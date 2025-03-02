using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Fungus;

namespace TremorMod.Content.Items.Armor.Fungus
{
	[AutoloadEquip(EquipType.Legs)]
	public class FungusGreaves : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 40000;
			Item.rare = 3;
			Item.defense = 7;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fungus Greaves");
			Tooltip.SetDefault("");
		}*/

		public override void UpdateEquip(Player player)
		{
		}

        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ModContent.ItemType<FungusElement>(), 14);
            recipe1.AddIngredient(ItemID.GlowingMushroom, 12);
            recipe1.AddIngredient(ItemID.GoldGreaves, 1);
            //recipe1.SetResult(this);
            recipe1.AddTile(16);
            recipe1.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ModContent.ItemType<FungusElement>(), 14);
            recipe2.AddIngredient(ItemID.GlowingMushroom, 12);
            recipe2.AddIngredient(ItemID.PlatinumGreaves, 1);
            //recipe2.SetResult(this);
            recipe2.AddTile(16);
            recipe2.Register();
        }
    }
}
