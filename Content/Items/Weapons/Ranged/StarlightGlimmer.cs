using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class StarlightGlimmer : ModItem
	{
		public override void SetDefaults()
		{
			Item.autoReuse = true;
			Item.useStyle = 5;
			Item.useAnimation = 12;
			Item.useTime = 12;

			Item.width = 50;
			Item.height = 18;
			Item.shoot = 12;
			Item.useAmmo = AmmoID.FallenStar;
			Item.UseSound = SoundID.Item9;
			Item.damage = 228;
			Item.shootSpeed = 14f;
			Item.noMelee = true;
			Item.value = 1000000;
			Item.rare = 2;

			Item.DamageType = DamageClass.Ranged;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Starlight Glimmer");
			// Tooltip.SetDefault("Shoots fallen stars");
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < 1; ++i) // Will shoot 3 bullets.
            {
                Projectile.NewProjectile(source, position, velocity + new Vector2(1, 1), type, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity + new Vector2(-1, -1), type, damage, knockback, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.StarCannon, 1);
			recipe.AddIngredient(ModContent.ItemType<Doomstone>(), 16);
			recipe.AddIngredient(3467, 20);
			recipe.AddIngredient(ItemID.MeteoriteBar, 20);
			recipe.AddIngredient(ItemID.FallenStar, 25);
			recipe.AddIngredient(ModContent.ItemType<ConcentratedEther>(), 28);
			//recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.Register();
		}
	}
}
