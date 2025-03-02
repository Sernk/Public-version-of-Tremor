using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class Volcannon : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 356;
			Item.DamageType = DamageClass.Magic;
			Item.width = 50;
			Item.height = 55;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.mana = 9;
			Item.useStyle = 5;
			Item.shoot = 376;
			Item.shootSpeed = 26f;
			Item.knockBack = 4;
			Item.value = 12000;
			Item.rare = 0;
			Item.UseSound = SoundID.Item100;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Volcannon");
			// Tooltip.SetDefault("");
		}

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

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < 1; ++i)
            {
                Projectile.NewProjectile(source, position, velocity + new Vector2(1, 1), type, damage, knockback, Main.myPlayer);
                Projectile.NewProjectile(source, position, velocity + new Vector2(2, 3), type, damage, knockback, Main.myPlayer);
                Projectile.NewProjectile(source, position, velocity + new Vector2(3, 2), type, damage, knockback, Main.myPlayer);
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer);
                Projectile.NewProjectile(source, position, velocity + new Vector2(-1, -1), type, damage, knockback, Main.myPlayer);
                Projectile.NewProjectile(source, position, velocity + new Vector2(-2, -3), type, damage, knockback, Main.myPlayer);
                Projectile.NewProjectile(source, position, velocity + new Vector2(-3, -2), type, damage, knockback, Main.myPlayer);
            }
            return false;
        }
    }
}
