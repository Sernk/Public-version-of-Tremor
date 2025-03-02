using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Armor.RedSteel
{
	[AutoloadEquip(EquipType.Legs)]
	public class RedSteelGreaves : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = 360;
			Item.rare = 2;
			Item.defense = 5;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Red Steel Greaves");
			// Tooltip.SetDefault("20% increased movement speed");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.2f;
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RedSteelArmorPiece>(), 5);
            recipe.AddIngredient(ModContent.ItemType<RedSteelBar>(), 6);
            recipe.AddTile(16);
            recipe.Register();
        }

    }
}
