using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class DragonRafale : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 236;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 50;
			Item.maxStack = 1;
			Item.height = 30;
			Item.useTime = 10;
			Item.useAnimation = 15;
			//item.shoot = mod.ProjectileType("DragonLaser");
			Item.shoot = 20;
			Item.useAmmo = AmmoID.Bullet;
			Item.shootSpeed = 15f;
			Item.useStyle = 5;
			Item.knockBack = 4;
			Item.value = 31000; ;
			Item.rare = 11;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Dragon Rafale");
			//Tooltip.SetDefault("Two round burst");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, -4);
		}

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity, ProjectileID.GreenLaser, damage, knockback, player.whoAmI);

            return false;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<DragonCapsule>(), 9);
			recipe.AddIngredient(ModContent.ItemType<EarthFragment>(), 14);
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe.AddTile(412);
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}