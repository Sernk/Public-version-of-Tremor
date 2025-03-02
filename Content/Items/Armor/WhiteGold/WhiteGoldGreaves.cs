using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Armor.WhiteGold
{
	[AutoloadEquip(EquipType.Legs)]
	public class WhiteGoldGreaves : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 38;
			Item.height = 22;

			Item.value = 10000;
			Item.rare = 11;
			Item.defense = 32;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("White Gold Greaves");
			// Tooltip.SetDefault("50% increased movement speed");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.5f;
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<WhiteGoldBar>(), 15);
            //recipe.SetResult(this);
            recipe.AddTile(ModContent.TileType<DivineForgeTile>());
            recipe.Register();
        }
    }
}
