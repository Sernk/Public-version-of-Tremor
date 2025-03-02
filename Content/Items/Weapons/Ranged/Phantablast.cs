using System;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class Phantablast : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 83;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 20;
			Item.height = 12;
			Item.useTime = 12;
			Item.useAnimation = 20;
			Item.useStyle = 5;
			Item.knockBack = 6;
			Item.value = 210000;
			Item.rare = 10;
			Item.useStyle = 5;
			Item.UseSound = SoundID.Item36;
			Item.noMelee = true;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 23f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Phantablast");
			//Tooltip.SetDefault("Fires your ammo in a blast\n" +
			//                   "50% chance to not consume ammo");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-18, -4);
		}

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 1; i < 6; i++)
            {
                // Randomize speed
                float lowerSpeed = 0.75f - i / 100f; // how low of a speed multiplier can we generate? in our example, 25% slower and lower
                float higherSpeed = 1.25f + i / 100f; // how high of a speed multiplier can we generate? in our example, 25% faster and higher
                Vector2 randomizedVelocity = velocity * Main.rand.NextFloat(lowerSpeed, higherSpeed); // our speed multiplied
                                                                                                      // Randomize the angle
                float spread = MathHelper.PiOver4; // we set our spread to a quarter of pi, which is a quarter circle, which is equivalent to 90° (a full circle is 360°, so half is 180°, so a quarter is 90°)
                spread /= 4; // you can manipulate the spread however you want, we make it quarter to end up with a 25° spread
                float magnitude = randomizedVelocity.LengthSquared(); // length is the x*x+y*y, we want the length squared, this is often refered to as its magnitude
                double baseAngle = randomizedVelocity.ToRotation(); // our base angle is the angle of velocity: atan2 of speedY, speedX
                double randomAngle = (Main.rand.NextDouble() - 0.5) * 2 * spread;
                double newAngle = baseAngle + randomAngle; // add the random angle to the angle we add
                randomizedVelocity = ((float)newAngle).ToRotationVector2() * magnitude; // make the new velocity based on our offset angle
                Projectile.NewProjectile(source, position, randomizedVelocity, type, damage, knockback, player.whoAmI);
            }
            return false;
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return !Main.rand.NextBool(2); 
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<AncientTechnology>(), 1);
			recipe.AddIngredient(3456, 30);
			recipe.AddIngredient(ModContent.ItemType<AirFragment>(), 25);
			//recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.Register();
		}
	}
}
