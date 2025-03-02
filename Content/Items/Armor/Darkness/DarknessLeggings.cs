using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.BossLoot.TheDarkEmperor;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.Darkness
{
	[AutoloadEquip(EquipType.Legs)]
	public class DarknessLeggings : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 22;
			Item.height = 18;
			Item.value = 600000;

			Item.rare = 11;
			Item.defense = 25;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Leggings of Darkness");
			// Tooltip.SetDefault("Increases life regeneration");
		}

		public override void UpdateEquip(Player player)
		{
			player.lifeRegen += 5;
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DarkGel>(), 45);
            recipe.AddIngredient(ModContent.ItemType<DarkMatter>(), 45);
            recipe.AddIngredient(ModContent.ItemType<DarkMass>(), 1);
            recipe.AddTile(247);
            recipe.Register();
        }
    }
}
