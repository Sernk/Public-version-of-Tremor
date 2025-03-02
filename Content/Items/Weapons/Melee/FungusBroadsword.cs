using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Fungus;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class FungusBroadsword : ModItem
	{
		public override void SetDefaults()
		{
			Item.rare = 3;
			Item.UseSound = SoundID.Item1;
			Item.useStyle = 1;
			Item.damage = 26;
			Item.useAnimation = 19;
			Item.useTime = 19;
			Item.width = 84;
			Item.height = 84;
			Item.shoot = 131;
			Item.shootSpeed = 15f;
			Item.knockBack = 3f;
			Item.DamageType = DamageClass.Melee;
			Item.value = Item.sellPrice(0, 0, 5, 0);
			Item.autoReuse = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fungus Broadsword");
		}*/

		public override void AddRecipes()
		{
			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ModContent.ItemType<FungusElement>(), 12);
			recipe1.AddIngredient(ItemID.GlowingMushroom, 9);
			recipe1.AddIngredient(ItemID.GoldBroadsword, 1);
			recipe1.AddTile(16);
			//recipe.SetResult(this);
			recipe1.Register();

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ModContent.ItemType<FungusElement>(), 12);
            recipe2.AddIngredient(ItemID.GlowingMushroom, 9);
			recipe2.AddIngredient(ItemID.PlatinumBroadsword, 1);
			recipe2.AddTile(16);
			//recipe2.SetResult(this);
			recipe2.Register();
        }
	}
}
