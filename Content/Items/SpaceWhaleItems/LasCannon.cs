using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.SpaceWhaleItems
{
	public class LasCannon : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 500;
			Item.DamageType = DamageClass.Ranged;
			Item.expert = true;
			Item.width = 90;
			Item.height = 36;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.useAmmo = AmmoID.Bullet;
			Item.useStyle = 5;
			Item.shootSpeed = 20f;
			Item.knockBack = 15;
			Item.value = 1000000;
			Item.rare = 10;
			Item.shoot = 440;
			Item.shootSpeed = 10f;
			Item.UseSound = SoundID.Item40;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Las Cannon");
			//Tooltip.SetDefault("Uses bullets as ammo");
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            type = 440; 
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
            return false; 
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-20, 0);
        }
    }
}
