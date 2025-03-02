using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Biomes.Ice.Items.Furniture
{
	public class IceGrandfatherClock : ModItem
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Glacier Wood Grandfather Clock");
			//Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 74;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useStyle = 1;
			Item.rare = 1;
			Item.consumable = true;
			Item.value = 2000;
			Item.createTile = ModContent.TileType<IceGrandfatherClockTile>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IronBar, 3);
			recipe.AddIngredient(ItemID.Glass, 6);
			recipe.AddIngredient(ModContent.ItemType<GlacierWood>(), 10);
			//recipe.SetResult(this);
			recipe.AddTile(106);
			recipe.Register();

			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ItemID.LeadBar, 3);
			recipe1.AddIngredient(ItemID.Glass, 6);
			recipe1.AddIngredient(ModContent.ItemType<GlacierWood>(), 10);
			//recipe1.SetResult(this);
			recipe1.AddTile(106);
			recipe1.Register();
		}
	}
}