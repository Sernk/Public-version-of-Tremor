using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Tiles;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Placeable
{
	public class CreepyThrone : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 48;
			Item.height = 64;
			Item.maxStack = 999;
			Item.value = 100;
			Item.rare = 1;
			Item.createTile = ModContent.TileType<CreepyThroneTile>();
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Creepy Throne");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SilverBar, 25);
			recipe.AddIngredient(ModContent.ItemType<MinotaurHorn>(), 2);
			recipe.AddIngredient(ItemID.Silk, 15);
			//recipe.SetResult(this);
			recipe.AddTile(106);
			recipe.Register();

			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ItemID.TungstenBar, 25);
			recipe1.AddIngredient(ModContent.ItemType<MinotaurHorn>(), 2);
			recipe1.AddIngredient(ItemID.Silk, 15);
			//recipe.SetResult(this);
			recipe1.AddTile(106);
			recipe1.Register();
		}
	}
}
