using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class WickedRing : ModItem
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
				Projectile.NewProjectile(Item.GetSource_FromThis(), position.X, position.Y, (float)(Math.Sin(offsetAngle) * 5f), (float)(Math.Cos(offsetAngle) * 5f), Item.shoot, damage, Item.playerIndexTheItemIsReservedFor);
				Projectile.NewProjectile(Item.GetSource_FromThis(), position.X, position.Y, (float)(-Math.Sin(offsetAngle) * 5f), (float)(-Math.Cos(offsetAngle) * 5f), Item.shoot, damage, Item.playerIndexTheItemIsReservedFor);
			}
			return false;
		}

		public override void SetDefaults()
		{

			Item.damage = 10;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 30;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.knockBack = 5;
			Item.value = 2500;
			Item.noUseGraphic = true;
			Item.rare = 3;
			Item.UseSound = SoundID.Item21;
			Item.autoReuse = true;
			Item.width = 28;
			Item.height = 30;
			Item.useStyle = 5;

			Item.noMelee = true;
			Item.shoot = 496;
			Item.shootSpeed = 20f;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Wicked Ring");
			// Tooltip.SetDefault("Releases shadow tentacles in all directions");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<RupicideBar>(), 3);
			recipe.AddIngredient(ItemID.DemoniteBar, 12);
			recipe.AddIngredient(ItemID.ShadowScale, 12);
			recipe.AddIngredient(ModContent.ItemType<WickedHeart>(), 1);
			recipe.AddTile(ModContent.TileType<NecromaniacWorkbenchTile>());
			recipe.Register();

			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ModContent.ItemType<RupicideBar>(), 3);
			recipe1.AddIngredient(ItemID.CrimtaneBar, 12);
			recipe1.AddIngredient(ItemID.TissueSample, 12);
			recipe1.AddIngredient(ModContent.ItemType<WickedHeart>(), 1);
			recipe1.AddTile(ModContent.TileType<NecromaniacWorkbenchTile>());
			recipe1.Register();
		}
	}
}
