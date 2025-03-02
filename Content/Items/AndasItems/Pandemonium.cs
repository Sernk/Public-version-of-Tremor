using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.AndasItems
{
	public class Pandemonium : ModItem
	{
		public override void SetDefaults()
		{ 
			Item.damage = 320;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 52;
			Item.height = 34;
			Item.useTime = 3;
			Item.useAnimation = 12;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 4f;
			Item.value = 600000;
			Item.rare = 0;
			Item.UseSound = SoundID.Item92;
			Item.autoReuse = false;
			Item.shootSpeed = 25f;
			Item.shoot = ModContent.ProjectileType<PandemoniumBullet>();
			Item.useAmmo = AmmoID.Bullet;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pandemonium");
			Tooltip.SetDefault("Shoots a burst of bullets\n" +
			"Bullets explode into firebals\n" +
			"75% chance not to consume ammo");
		}*/

		public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (var tooltip in tooltips)
            {
                if (tooltip.Mod == "Terraria" && tooltip.Name == "ItemName")
                {
                    tooltip.OverrideColor = new Color(238, 194, 73); 
                }
			}
		}
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return !Main.rand.NextBool(3);
        }

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float speedX = velocity.X + Main.rand.Next(-15, 16) * 0.05f;
            float speedY = velocity.Y + Main.rand.Next(-15, 16) * 0.05f;

            Projectile.NewProjectile(source, position.X, position.Y, speedX, speedY, type, damage, knockback, player.whoAmI);

            if (Main.rand.NextBool(2))
            {
                Projectile.NewProjectile(source, position.X, position.Y, speedX, speedY, ModContent.ProjectileType<PandemoniumBullet>(), damage, knockback, player.whoAmI);
            }

            return false; 
        }

    }
}
