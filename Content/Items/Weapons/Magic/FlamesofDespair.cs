using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class FlamesofDespair : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 22;
			Item.damage = 152;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 15;
			Item.value = 100000;
			Item.useTime = 38;
			Item.useAnimation = 38;
			Item.shoot = ModContent.ProjectileType<FlamesofDespairPro>();
			Item.shootSpeed = 30f;
			Item.useStyle = 5;
			Item.rare = 11;
			Item.UseSound = SoundID.Item117;
			//Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.knockBack = 3;
			Item.autoReuse = false;

			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Flames of Despair");
			//Tooltip.SetDefault("'Summons homing flames of oblivion'");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.Yellow;
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
