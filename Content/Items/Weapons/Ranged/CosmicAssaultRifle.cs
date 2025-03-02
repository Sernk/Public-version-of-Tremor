using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class CosmicAssaultRifle : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 190;
			Item.width = 64;
			Item.height = 28;
			Item.DamageType = DamageClass.Ranged;
			Item.useTime = 15;
			Item.shoot = 207;
			Item.shootSpeed = 20f;
			Item.useAnimation = 15;
			Item.useStyle = 5;
			Item.knockBack = 5;
			Item.value = 1000000;
			Item.useAmmo = AmmoID.Bullet;
			Item.rare = 11;
			Item.crit = 7;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Cosmic Assault Rifle");
			//Tooltip.SetDefault("Uses bullets as ammo\n" +
			//"Shoots homing bullets");
		}

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity, ProjectileID.ChlorophyteBullet, damage, knockback, player.whoAmI);

            return false;
        }

        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-22, 0);
		}

    }
}