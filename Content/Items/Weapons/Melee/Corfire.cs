using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class Corfire : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(3279);
			Item.damage = 56;
			Item.DamageType = DamageClass.Melee;
            Item.width = 30;
			Item.height = 26;
			Item.shoot = ModContent.ProjectileType<CorfirePro>();
			Item.knockBack = 4;
			Item.value = 10000;
			Item.rare = 2;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Corfire");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(3290, 1);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.AddIngredient(ItemID.CursedFlame, 18);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}