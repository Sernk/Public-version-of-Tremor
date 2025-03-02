using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.NPCs.Bosses.NovaPillar.Items
{
	public class NovaDye : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 16;
			Item.height = 24;
			Item.maxStack = 99;
			Item.value = Item.sellPrice(0, 2, 50, 0);
			Item.rare = 4;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Dye");
			Tooltip.SetDefault("");
		}*/

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(ModContent.ItemType<NovaFragment>(), 10);
			recipe.AddTile(TileID.DyeVat);
			//recipe.SetResult(this, 1);
			recipe.Register();
		}
	}
}
