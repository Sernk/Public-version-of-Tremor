using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Fungus;

namespace TremorMod.Content.Items.Tools
{
	public class FungusPickaxe : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 10;
            Item.DamageType = DamageClass.Melee;
            Item.width = 32;
			Item.height = 32;
			Item.useTime = 15;
			Item.useAnimation = 20;
			Item.pick = 85;
			Item.useStyle = 1;
			Item.knockBack = 2;
			Item.value = 1000;
			Item.rare = 3;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fungus Pickaxe");
			Tooltip.SetDefault("");
		}*/

		public override void AddRecipes()
		{
			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ModContent.ItemType<FungusElement>(), 13);
			recipe1.AddIngredient(ItemID.GlowingMushroom, 10);
			recipe1.AddIngredient(ItemID.GoldPickaxe, 1);
			recipe1.AddTile(16);
			//recipe.SetResult(this);
			recipe1.Register();

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ModContent.ItemType<FungusElement>(), 13);
			recipe2.AddIngredient(ItemID.GlowingMushroom, 10);
			recipe2.AddIngredient(ItemID.PlatinumPickaxe, 1);
			recipe2.AddTile(16);
			//recipe.SetResult(this);
			recipe2.Register();
		}
	}
}
