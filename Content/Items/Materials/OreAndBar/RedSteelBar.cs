using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Materials.OreAndBar
{
	public class RedSteelBar : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 24;
			Item.maxStack = 99;
			Item.value = 300;
			Item.rare = 1;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.createTile = ModContent.TileType<RedSteelBarTile>();
			Item.useStyle = 1;
			Item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Red Steel Bar");
			// Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(2);
			recipe.AddIngredient(ModContent.ItemType<ChippyRedSteelSword>());
			recipe.AddTile(17);
			recipe.Register();
			
			Recipe recipe1 = CreateRecipe(3);
			recipe1.AddIngredient(ModContent.ItemType<FaultyRedSteelShield>());
			recipe1.AddTile(17);
			recipe1.Register();
			
			Recipe recipe2 = CreateRecipe(2);
			recipe2.AddIngredient(ModContent.ItemType<RedSteelArmorPiece>());
			recipe2.AddTile(17);
			recipe2.Register();
		}
	}
}