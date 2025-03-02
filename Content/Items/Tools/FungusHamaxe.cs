using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Fungus;

namespace TremorMod.Content.Items.Tools
{
	public class FungusHamaxe : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 16;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 22;
			Item.useAnimation = 18;
			Item.axe = 13;
			Item.hammer = 75;
			Item.useStyle = 1;
			Item.knockBack = 2;
			Item.value = 1000;
			Item.rare = 3;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fungus Hamaxe");
			Tooltip.SetDefault("");
		}*/

		public override void AddRecipes()
		{
			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ModContent.ItemType<FungusElement>(), 11);
            recipe1.AddIngredient(ItemID.GlowingMushroom, 8);
			recipe1.AddIngredient(ItemID.GoldAxe, 1);
			recipe1.AddIngredient(ItemID.GoldHammer, 1);
			recipe1.AddTile(16);
			//recipe.SetResult(this);
			recipe1.Register();

			Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ModContent.ItemType<FungusElement>(), 11);
            recipe2.AddIngredient(ItemID.GlowingMushroom, 8);
			recipe2.AddIngredient(ItemID.PlatinumAxe, 1);
			recipe2.AddIngredient(ItemID.PlatinumHammer, 1);
			recipe2.AddTile(16);
			//recipe.SetResult(this);
			recipe2.Register();
		}
	}
}
