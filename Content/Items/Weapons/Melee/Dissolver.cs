using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class Dissolver : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(3279);
			Item.damage = 58;
			Item.DamageType = DamageClass.Melee;
            Item.width = 30;
			Item.height = 26;
			Item.shoot = ModContent.ProjectileType<DissolverPro>();
			Item.knockBack = 4;
			Item.value = 10000;
			Item.rare = 4;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Dissolver");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(3290, 1);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.AddIngredient(ItemID.Ichor, 18);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
