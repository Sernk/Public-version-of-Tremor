using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class Durian : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 18;
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.mana = 9;
			Item.height = 20;
			Item.useTime = 20;
			Item.useAnimation = 12;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 6;
			Item.value = 100000;
			Item.rare = 3;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 374;
			Item.shootSpeed = 12f;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Durian");
			//Tooltip.SetDefault("");
		}

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < 1; ++i)
            {
                Projectile.NewProjectile(source, position, velocity + new Vector2(2, 2), type, damage, knockback, Main.myPlayer);
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer);
                Projectile.NewProjectile(source, position, velocity - new Vector2(2, 2), type, damage, knockback, Main.myPlayer);
            }
            return false;
        }
    }
}
