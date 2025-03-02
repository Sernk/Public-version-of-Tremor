using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class Avenger : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(3279);
			Item.damage = 17;
			Item.DamageType = DamageClass.Melee;
            Item.width = 30;
			Item.height = 26;
			Item.shoot = ModContent.ProjectileType<AvengerPro>();
			Item.knockBack = 4;
			Item.value = 10000;
			Item.rare = 2;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Avenger");
			Tooltip.SetDefault("");
		}*/

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 18);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
