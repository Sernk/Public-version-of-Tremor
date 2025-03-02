using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class PartyOver : ModItem
	{
		public override void SetDefaults()
		{
			Item.useStyle = 5;
			Item.useAnimation = 24;
			Item.useTime = 9;
			Item.width = 24;
			Item.height = 14;
			Item.shoot = 587;
			Item.damage = 122;
			Item.shootSpeed = 10f;
			Item.noMelee = true;
			Item.value = Item.sellPrice(0, 0, 50, 0);
			Item.knockBack = 1.25f;
			Item.scale = 0.85f;
			Item.rare = 2;
			Item.DamageType = DamageClass.Ranged;
			Item.crit = 7;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Party Over");
			//Tooltip.SetDefault("");
		}


        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < 1; ++i) // Will shoot 3 bullets.
            {
                Projectile.NewProjectile(source, position, velocity + new Vector2(2, 2), type, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity + new Vector2(1, 1), type, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity + new Vector2(-1, -1), type, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity + new Vector2(-2, -2), type, damage, knockback, player.whoAmI);
            }
            return false;
        }

        public override Vector2? HoldoutOffset()
		{
			return Vector2.Zero;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SoulofFlight, 20);
			recipe.AddIngredient(ModContent.ItemType<ConcentratedEther>(), 8);
			recipe.AddIngredient(ModContent.ItemType<CandyBar>(), 15);
			recipe.AddTile(412);
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
