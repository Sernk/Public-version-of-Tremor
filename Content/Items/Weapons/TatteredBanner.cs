using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Crystal;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Weapons
{
	public class TatteredBanner : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 48;
			Item.height = 64;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.value = 50000;
			Item.rare = 11;
			Item.createTile = ModContent.TileType<TatteredBannerTile>();
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Tattered Banner");
			// Tooltip.SetDefault("25% increased damage if placed");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Gloomstone>(), 10);
			recipe.AddIngredient(ModContent.ItemType<UnstableCrystal>(), 2);
			recipe.AddIngredient(ItemID.TatteredCloth, 25);
			//recipe.SetResult(this);
			recipe.AddTile(106);
			recipe.Register();
		}
	}
}
