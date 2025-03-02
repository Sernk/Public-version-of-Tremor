using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class SpectralBlade : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 92;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 42;
			Item.height = 46;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.shoot = 297;
			Item.shootSpeed = 15f;
			Item.useStyle = 1;
			Item.knockBack = 2;
			Item.value = 46000;
			Item.rare = 8;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Spectral Blade");
			// Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SpectreBar, 18);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
