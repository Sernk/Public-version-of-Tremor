using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class Megavolt : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 223;
			Item.width = 18;
			Item.height = 56;
			Item.DamageType = DamageClass.Ranged;
			Item.useTime = 30;
			Item.shoot = 1;
			Item.shootSpeed = 12f;
			Item.useAnimation = 30;
			Item.useStyle = 5;
			Item.knockBack = 5;
			Item.value = 25000;
			Item.useAmmo = AmmoID.Arrow;
			Item.rare = 3;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Megavolt");
			//Tooltip.SetDefault("Shoots the charged arrows");
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			int i = Main.myPlayer;
			float num72 = Item.shootSpeed;
			int num73 = Item.damage;
			float num74 = Item.knockBack;
			num74 = player.GetWeaponKnockback(Item, num74);
			player.itemTime = Item.useTime;
			Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
			Vector2 value = Vector2.UnitX.RotatedBy(player.fullRotation, default(Vector2));
			Vector2 vector3 = Main.MouseWorld - vector2;
			float num78 = Main.mouseX + Main.screenPosition.X - vector2.X;
			float num79 = Main.mouseY + Main.screenPosition.Y - vector2.Y;
			if (player.gravDir == -1f)
			{
				num79 = Main.screenPosition.Y + Main.screenHeight - Main.mouseY - vector2.Y;
			}
			float num80 = (float)Math.Sqrt(num78 * num78 + num79 * num79);
			float num81 = num80;
			if ((float.IsNaN(num78) && float.IsNaN(num79)) || (num78 == 0f && num79 == 0f))
			{
				num78 = player.direction;
				num79 = 0f;
				num80 = num72;
			}
			else
			{
				num80 = num72 / num80;
			}
			num78 *= num80;
			num79 *= num80;
			int num146 = 4;
			if (Main.rand.NextBool(2))
			{
				num146++;
			}
			if (Main.rand.NextBool(4))
			{
				num146++;
			}
			if (Main.rand.NextBool(8))
			{
				num146++;
			}
			if (Main.rand.Next(16) == 0)
			{
				num146++;
			}
            IEntitySource projectileSource = player.GetSource_ItemUse(Item);
            for (int num147 = 0; num147 < num146; num147++)
			{
				float num148 = num78;
				float num149 = num79;
				float num150 = 0.05f * num147;
				num148 += Main.rand.Next(-35, 36) * num150;
				num149 += Main.rand.Next(-35, 36) * num150;
				num80 = (float)Math.Sqrt(num148 * num148 + num149 * num149);
				num80 = num72 / num80;
				num148 *= num80;
				num149 *= num80;
				float x4 = vector2.X;
				float y4 = vector2.Y;
                Projectile.NewProjectile(projectileSource, new Vector2(x4, y4), new Vector2(num148, num149), ModContent.ProjectileType<ChargedArrow>(), num73, num74, i, 0f, 0f);
            }
			return false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<CometiteBar>(), 12);
			recipe.AddIngredient(ItemID.MartianConduitPlating, 30);
			recipe.AddIngredient(ModContent.ItemType<LunarRoot>(), 12);
			recipe.AddIngredient(ModContent.ItemType<NightCore>(), 5);
			recipe.AddTile(412);
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
