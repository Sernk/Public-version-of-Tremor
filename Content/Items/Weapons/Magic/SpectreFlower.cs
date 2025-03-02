using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class SpectreFlower : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 60;
			Item.DamageType = DamageClass.Magic;
			Item.width = 46;
			Item.height = 48;
			Item.mana = 15;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.noMelee = true;
			Item.knockBack = 6;
			Item.value = 30000;
			Item.rare = 8;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<SpectreFlowerPro>();
			Item.shootSpeed = 6f;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Spectre Flower");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SpectreBar, 17);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
