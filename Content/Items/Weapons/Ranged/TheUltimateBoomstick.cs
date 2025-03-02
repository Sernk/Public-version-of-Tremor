using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class TheUltimateBoomstick : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 312;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 78;
			Item.height = 22;
			Item.useTime = 45;
			Item.useAnimation = 45;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = 13800;
			Item.rare = 10;
			Item.UseSound = SoundID.Item36;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 5f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("The Ultimate Boomstick");
			/* Tooltip.SetDefault("Has a chance to shoot moon flames\n" +
"'What can be better than a giant shotgun!?'"); */
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-18, 0);
		}


        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int projectileType = ProjectileID.MoonlordBullet;

            if (Main.rand.NextBool(4))
            {
                projectileType = ProjectileID.LunarFlare;
            }

            for (int i = 0; i < 1; ++i) // Will shoot 3 bullets.
            {
                Projectile.NewProjectile(source, position, velocity + new Vector2(2, 2), projectileType, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity + new Vector2(1, 1), projectileType, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, projectileType, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity + new Vector2(-1, -1), projectileType, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity + new Vector2(-2, -2), projectileType, damage, knockback, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<VoidBar>(), 5);
			recipe.AddIngredient(3467, 5);
			recipe.AddIngredient(ModContent.ItemType<MultidimensionalFragment>(), 10);
			recipe.AddIngredient(ModContent.ItemType<ConcentratedEther>(), 15);
			//recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.Register();
		}
	}
}
