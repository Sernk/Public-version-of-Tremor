using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Magic	
{
	public class ChargedLamp : ModItem
	{

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float spread = 45f * 0.0174f;
            double startAngle = Math.Atan2(velocity.X, velocity.Y) - spread / 2;
            double deltaAngle = spread / 8f;
            double offsetAngle;
            int i;
            for (i = 0; i < 4; i++)
            {
                offsetAngle = (startAngle + deltaAngle * (i + i * i) / 2f) + 32f * i;
                Projectile.NewProjectile(Item.GetSource_FromThis(), position.X, position.Y, (float)(Math.Sin(offsetAngle) * 5f), (float)(Math.Cos(offsetAngle) * 5f), Item.shoot, damage, knockback, Item.playerIndexTheItemIsReservedFor);
                Projectile.NewProjectile(Item.GetSource_FromThis(), position.X, position.Y, (float)(-Math.Sin(offsetAngle) * 5f), (float)(-Math.Cos(offsetAngle) * 5f), Item.shoot, damage, knockback, Item.playerIndexTheItemIsReservedFor);
            }
            return false;
        }

		public override void SetDefaults()
		{

			Item.damage = 60;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 26;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.knockBack = 5;
			Item.value = 2500;
			Item.noUseGraphic = true;
			Item.rare = 5;
			Item.UseSound = SoundID.Item21;
			Item.autoReuse = true;
			Item.width = 28;
			Item.height = 30;
			Item.useStyle = 5;

			Item.noMelee = true;
			Item.shoot = 709;
			Item.shootSpeed = 20f;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Charged Lamp");
			// Tooltip.SetDefault("Releases electric blasts in all directions");
		}
	}
}
