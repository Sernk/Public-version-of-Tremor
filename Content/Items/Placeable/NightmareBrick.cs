using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Tiles;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Placeable
{
	public class NightmareBrick : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 12;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.value = 10000;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.rare = 11;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<NightmareBrickTile>();
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Nightmare Brick");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<NightmareBrickWall>(), 4);
			//recipe.SetResult(this, 1);
			recipe.AddTile(17);
			recipe.Register();

			Recipe recipe1 = CreateRecipe(2);
			recipe1.AddIngredient(ModContent.ItemType<NightmareOre>(), 1);
			recipe1.AddIngredient(ItemID.StoneBlock, 1);
			//recipe.SetResult(this, 2);
			recipe1.AddTile(17);
			recipe1.Register();
		}
	}
}
