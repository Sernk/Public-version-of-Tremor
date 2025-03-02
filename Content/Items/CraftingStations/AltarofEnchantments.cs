using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Tiles;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.CraftingStations
{
	public class AltarofEnchantments : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 50;
			Item.height = 26;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;

			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.value = 150;
            Item.createTile = ModContent.TileType<AltarofEnchantmentsTile>();
        }

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Altar of Enchantments");
			Tooltip.SetDefault("Allows you to improve some items");
		}*/

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.StoneBlock, 30);
			recipe.AddIngredient(ModContent.ItemType<StoneofLife>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Gloomstone>(), 30);
            recipe.AddIngredient(ItemID.Book, 1);
			//recipe.SetResult(this);
            recipe.Register();
        }
	}
}
