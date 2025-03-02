using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Materials
{
	public class SteelBar : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 24;
			Item.maxStack = 99;
			Item.value = 300;
			Item.rare = 1;
			Item.createTile = ModContent.TileType<SteelBarTile>();
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
		}

        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Steel Bar");
			Tooltip.SetDefault("");
		}*/

        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.IronBar, 2);
            recipe1.AddIngredient(ModContent.ItemType<Charcoal>(), 2);
            recipe1.AddTile(ModContent.TileType<BlastFurnaceTile>()); // Здесь нужно использовать плитку, а не предмет
            recipe1.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.LeadBar, 2);
            recipe2.AddIngredient(ModContent.ItemType<Charcoal>(), 2);
            recipe2.AddTile(ModContent.TileType<BlastFurnaceTile>()); // Аналогично
            recipe2.Register();
        }

    }
}
