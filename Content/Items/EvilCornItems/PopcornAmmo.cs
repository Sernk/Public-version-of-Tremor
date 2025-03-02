using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.EvilCornItems
{
	public class PopcornAmmo : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 22;
			Item.height = 22;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 1.5f;
			Item.value = 10;
			Item.rare = 2;
			Item.shoot = ModContent.ProjectileType<PopcornAmmoPro>();
			Item.ammo = Item.type;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Popcorn");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Corn>(), 1);
			//recipe.SetResult(this, 25);
			recipe.AddTile(17);
			recipe.Register();
		}
	}
}
