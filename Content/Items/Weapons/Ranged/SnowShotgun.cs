using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class SnowShotgun : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 17;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 26;
			Item.maxStack = 1;
			Item.height = 56;
			Item.useTime = 32;
			Item.useAnimation = 30;
			Item.useStyle = 5;
			Item.knockBack = 4;
			Item.value = 100000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item36;
			Item.autoReuse = false;
			Item.shoot = 166;
			Item.shootSpeed = 10f;
			Item.useAmmo = AmmoID.Snowball;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Snow Shotgun");
			// Tooltip.SetDefault("");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-18, -4);
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
    }
}