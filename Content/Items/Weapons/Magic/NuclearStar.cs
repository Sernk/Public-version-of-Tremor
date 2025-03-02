using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Tiles;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Items.BossLoot.TheDarkEmperor;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class NuclearStar : ModItem
	{

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float spread = 45f * 0.0174f; 
            double startAngle = Math.Atan2(velocity.Y, velocity.X) - spread / 2; 
            double deltaAngle = spread / 8f;
            double offsetAngle;

            for (int i = 0; i < 4; i++)
            {
                offsetAngle = (startAngle + deltaAngle * (i + i * i) / 2f) + 32f * i;

                float speedX = (float)(Math.Cos(offsetAngle) * 5f);
                float speedY = (float)(Math.Sin(offsetAngle) * 5f);

                Projectile.NewProjectile(source, position.X, position.Y, speedX, speedY, type, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position.X, position.Y, -speedX, -speedY, type, damage, knockback, player.whoAmI);
            }

            return false;
        }

        public override void SetDefaults()
		{
			Item.damage = 500;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 50;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.knockBack = 5;
			Item.value = 2500000;
			Item.rare = 9;
			Item.UseSound = SoundID.Item84;
			Item.autoReuse = true;
			Item.width = 28;
			Item.height = 30;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.shoot = ModContent.ProjectileType<NuclearStarPro>();
			Item.shootSpeed = 20f;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Nuclear Star");
			//Tooltip.SetDefault("Creates nuclear beams.");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<StarBar>(), 25);
			recipe.AddIngredient(ModContent.ItemType<SoulofFight>(), 25);
			recipe.AddIngredient(ItemID.LunarBar, 30);
			recipe.AddIngredient(ItemID.Amber, 16);
			recipe.AddIngredient(ModContent.ItemType<Blasticyde>(), 10);
			recipe.AddIngredient(ModContent.ItemType<AngryShard>(), 15);
			recipe.AddTile(ModContent.TileType<StarvilTile>());
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
