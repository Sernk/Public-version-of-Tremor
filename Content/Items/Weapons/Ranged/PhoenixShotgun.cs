using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.HeaterOfWorldsItems;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class PhoenixShotgun : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 26;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 46;
			Item.height = 18;
			Item.useTime = 32;
			Item.useAnimation = 32;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = 16000;
			Item.rare = 3;
			Item.UseSound = SoundID.Item36;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 5f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Phoenix Shotgun");
			//Tooltip.SetDefault("Uses bullets as ammo\n" +
			//"Transforms bullets into fireballs");
		}

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int newProjectileType = ProjectileID.DD2FlameBurstTowerT2Shot;

            Projectile.NewProjectile(source, position, velocity, newProjectileType, damage, knockback, player.whoAmI);

            Projectile.NewProjectile(source, position, velocity + new Vector2(2, 2), newProjectileType, damage, knockback, player.whoAmI);
            Projectile.NewProjectile(source, position, velocity + new Vector2(1, 1), newProjectileType, damage, knockback, player.whoAmI);
            Projectile.NewProjectile(source, position, velocity, newProjectileType, damage, knockback, player.whoAmI);
            Projectile.NewProjectile(source, position, velocity + new Vector2(-1, -1), newProjectileType, damage, knockback, player.whoAmI);
            Projectile.NewProjectile(source, position, velocity + new Vector2(-2, -2), newProjectileType, damage, knockback, player.whoAmI);

            return false; 
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<FireFragment>(), 15);
			recipe.AddIngredient(ModContent.ItemType<MoltenParts>(), 1);
			//recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.Register();
		}
	}
}
