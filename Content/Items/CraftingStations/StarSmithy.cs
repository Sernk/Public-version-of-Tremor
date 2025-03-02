using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.CraftingStations
{
	public class StarSmithy : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 46;
			Item.height = 46;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.value = 150;
			Item.createTile = ModContent.TileType<StarvilTile>();
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Starvil");
			Tooltip.SetDefault("Allows you to treat space materials");
		}*/

		public override void AddRecipes()
		{
			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ItemID.MeteoriteBar, 15);
			recipe1.AddIngredient(ItemID.GoldBar, 15);
			recipe1.AddIngredient(ModContent.ItemType<VoidBar>(), 15);
			recipe1.AddIngredient(ModContent.ItemType<Squorb>(), 3);
			recipe1.AddIngredient(ItemID.FallenStar, 5);
			//recipe.SetResult(this);
			recipe1.AddTile(412);
			recipe1.Register();

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ItemID.MeteoriteBar, 15);
			recipe2.AddIngredient(ItemID.PlatinumBar, 15);
			recipe2.AddIngredient(ModContent.ItemType<VoidBar>(), 15);
            recipe2.AddIngredient(ModContent.ItemType<Squorb>(), 3);
            recipe2.AddIngredient(ItemID.FallenStar, 5);
			//recipe.SetResult(this);
			recipe2.AddTile(412);
			recipe2.Register();
		}
	}
}
