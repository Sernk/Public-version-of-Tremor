using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class AlienBlaster : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 136;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 4;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 9;
			Item.useAnimation = 9;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = 28440;
			Item.rare = 8;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 440;
			Item.shootSpeed = 5f;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Alien Blaster");
			// Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SpaceGun, 1);
			recipe.AddIngredient(ModContent.ItemType<NightmareBar>(), 15);
			recipe.AddIngredient(ItemID.MeteoriteBar, 25);
			recipe.AddIngredient(ModContent.ItemType<ConcentratedEther>(), 22);
			recipe.AddIngredient(ModContent.ItemType<StarBar>(), 5);
			recipe.AddIngredient(ModContent.ItemType<Phantaplasm>(), 10);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<StarvilTile>());
			recipe.Register();
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int ShotAmt = 2;
            int spread = 5;
            float spreadMult = 0.3f;

            Vector2 vector2 = new Vector2();

            for (int i = 0; i < ShotAmt; i++)
            {
                float vX = 8 * velocity.X + Main.rand.Next(-spread, spread + 1) * spreadMult;
                float vY = 8 * velocity.Y + Main.rand.Next(-spread, spread + 1) * spreadMult;

                float angle = (float)Math.Atan(vY / vX);
                vector2 = new Vector2(position.X + 75f * (float)Math.Cos(angle), position.Y + 75f * (float)Math.Sin(angle));
                float mouseX = Main.mouseX + Main.screenPosition.X;
                if (mouseX < player.position.X)
                {
                    vector2 = new Vector2(position.X - 75f * (float)Math.Cos(angle), position.Y - 75f * (float)Math.Sin(angle));
                }

                Projectile.NewProjectile(source, vector2.X, vector2.Y, vX, vY, type, damage, knockback, Main.myPlayer);
            }
            return false;
        }
	}
}
