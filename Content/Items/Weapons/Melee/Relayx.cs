using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class Relayx : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 95;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.shoot = ModContent.ProjectileType<RelayxProj>();
			Item.shootSpeed = 6f;
			Item.knockBack = 6;
			Item.value = 1000000;
			Item.rare = 11;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.expert = true;

		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Relayx");
			// Tooltip.SetDefault("Feel the power of the Titan");
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 59);
			}
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (Main.rand.NextBool(8))
			{
				if (Main.rand.NextBool(3))
				{
					Projectile.NewProjectile(Item.GetSource_FromThis(), position.X, position.Y, velocity.X, velocity.Y, ModContent.ProjectileType<RelayxDragonBig>(), Item.damage + 200, 10, Main.myPlayer);
				}
				else
				{
					Projectile.NewProjectile(Item.GetSource_FromThis(), position.X, position.Y, velocity.X, velocity.Y, ModContent.ProjectileType<RelayxDragon>(), Item.damage + 100, 10, Main.myPlayer);
				}
			}
			else
			{
				Projectile.NewProjectile(Item.GetSource_FromThis(), position.X, position.Y, velocity.X + 1, velocity.Y + 1, type, Item.damage - 20, Main.myPlayer);
				Projectile.NewProjectile(Item.GetSource_FromThis(), position.X, position.Y, velocity.X, velocity.Y, type, Item.damage - 20, Main.myPlayer);
			}
			return false;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			TooltipLine tip = new TooltipLine(Mod, "TremorMod:Tooltip", "-Donator Items-");
			tip.OverrideColor = new Color(119, 200, 203);
			tooltips.Insert(3, tip);
		}
	}
}
