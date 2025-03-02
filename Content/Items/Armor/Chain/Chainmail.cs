using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;

namespace TremorMod.Content.Items.Armor.Chain
{
	[AutoloadEquip(EquipType.Body)]
	public class Chainmail : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 18;
			Item.value = Item.sellPrice(silver: 8);
			Item.rare = 1;
			Item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Chain Mail");
			// Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IronBar, 25);
			recipe.AddIngredient(ModContent.ItemType<InvarBar>());
			recipe.AddIngredient(ItemID.Chain);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.LeadBar, 25);
            recipe1.AddIngredient(ModContent.ItemType<InvarBar>());
            recipe1.AddIngredient(ItemID.Chain);
            recipe1.AddTile(TileID.Anvils);
            recipe1.Register();
        }
	}
}
