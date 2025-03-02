using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class SnakeDevourer : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 295;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 58;
			Item.height = 26;
			Item.useTime = 9;
			Item.useAnimation = 9;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.useAmmo = AmmoID.Bullet;
			Item.value = 1000000;
			Item.rare = 11;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 440;
			Item.shootSpeed = 6f;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Snake Devourer");
			//Tooltip.SetDefault("Uses bullets as ammo");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-12, -2);
		}

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) 
        {
            int newProjectileType = ProjectileID.LaserMachinegunLaser; 
            Projectile.NewProjectile(source, position, velocity, newProjectileType, damage, knockback, player.whoAmI);
            return false;
        }
    }
}