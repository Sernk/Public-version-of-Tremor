using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Materials.OreAndBar
{
	public class NanoBar : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 30;
			Item.maxStack = 99;
			Item.value = 10000;
			Item.rare = 6;
			Item.createTile = ModContent.TileType<NanoBarTile>();
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nano Bar");
			Tooltip.SetDefault("Pulsing with pure energy");
		}*/

		public override void AddRecipes()
		{
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.TitaniumBar, 1);
			recipe1.AddIngredient(ItemID.SoulofNight, 1);
			recipe1.AddIngredient(ItemID.SoulofLight, 1);
			recipe1.AddIngredient(ItemID.Nanites, 1);
			//recipe1.SetResult(this, 2);
			recipe1.AddTile(134);
            recipe1.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.AdamantiteBar, 1);
			recipe2.AddIngredient(ItemID.SoulofNight, 1);
			recipe2.AddIngredient(ItemID.SoulofLight, 1);
			recipe2.AddIngredient(ItemID.Nanites, 1);
			//recipe2.SetResult(this, 2);
			recipe2.AddTile(134);
            recipe2.Register();
        }

	}
}
