using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class Bolter : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 43;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 46;
			Item.height = 32;
			Item.useTime = 9;
			Item.useAnimation = 9;
			Item.shoot = 1;
			Item.useAmmo = AmmoID.Arrow;
			Item.shootSpeed = 30f;
			Item.useStyle = 5;
			Item.knockBack = 4;
			Item.value = 90000;
			Item.rare = 7;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Bolter");
			//Tooltip.SetDefault("Quickly launches arrows\n" +
			//"Has 50% chance to shoot a Hellfire arrow");
		}

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 50f;
            position += muzzleOffset;
            if (Main.rand.NextBool(4))
            {
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HellfireArrow, damage, knockback, player.whoAmI);
            }
            else
            {
                Projectile.NewProjectile(source, position, velocity, ProjectileID.WoodenArrowFriendly, damage, knockback, player.whoAmI);
            }

            return false; 
        }
    }
}