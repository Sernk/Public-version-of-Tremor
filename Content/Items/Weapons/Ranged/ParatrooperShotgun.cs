using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Ranged
{

	public class ParatrooperShotgun : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 300;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 46;
			Item.height = 28;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.useStyle = 5;
			Item.knockBack = 6;
			Item.value = 651000;
			Item.rare = 11;
			Item.useStyle = 5;
			Item.UseSound = SoundID.Item36;
			Item.noMelee = true;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 23f;
			Item.useAmmo = AmmoID.Bullet;

		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Paratrooper Shotgun");
			//Tooltip.SetDefault("Has 33% chance not to consume ammo");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
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

        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextBool(3);
		}
	}
}
