using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class FrostFreshness : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 8;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = 5;
			Item.staff[Item.type] = true;
			//item.noMelee = true;
			Item.knockBack = 5;
			Item.value = 1500;
			Item.rare = 3;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = 309;
			Item.shootSpeed = 8f;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Frost Freshness");
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
