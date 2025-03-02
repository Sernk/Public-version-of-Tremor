using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class ParaxydeStormbow : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 68;
			//Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 16;
			Item.height = 32;
			Item.useTime = 15;
			Item.shoot = 1;
			Item.shootSpeed = 11f;
			Item.useAnimation = 15;
			Item.useStyle = 5;
			Item.knockBack = 1;
			Item.useAmmo = AmmoID.Arrow;
			Item.value = 216000;
			Item.rare = 5;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;

		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Paraxyde Stormbow");
			//Tooltip.SetDefault("Has 33% chance to shoot paraxyde crystal");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, -2);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ParaxydeShard>(), 13);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<AlchematorTile>());
			recipe.Register();
		}

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (Main.rand.NextBool(3)) 
            {
                Projectile.NewProjectile(source, position, velocity, ProjectileID.CrystalPulse2, damage, knockback, player.whoAmI);
            }
            else
            {
                Projectile.NewProjectile(source, position, velocity, ProjectileID.WoodenArrowFriendly, damage, knockback, player.whoAmI);
            }

            return false; 
        }
    }
}
