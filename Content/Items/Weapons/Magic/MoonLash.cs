using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class MoonLash : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 259;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 20;
			Item.width = 34;
			Item.height = 30;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.useStyle = 1;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = 13800;
			Item.rare = 10;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = false;
			Item.shoot = 645;
			Item.shootSpeed = 12f;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Moon Lash");
			//Tooltip.SetDefault("Erupts three moon flame bolts");
		}

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			for (int i = 0; i < 1; ++i) // Will shoot 3 bullets.
			{
                Projectile.NewProjectile(source, position, velocity + new Vector2(1, 1), type, damage, knockback, Main.myPlayer);
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer);
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer);
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer);
                Projectile.NewProjectile(source, position, velocity - new Vector2(1, 1), type, damage, knockback, Main.myPlayer);
            }
			return false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ScourgeofFlames>(), 1);
			recipe.AddIngredient(3467, 15);
			recipe.AddIngredient(ModContent.ItemType<NightmareBar>(), 11);
			recipe.AddIngredient(ItemID.PlatinumBar, 9);
			recipe.AddIngredient(ItemID.GoldBar, 9);
			//recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.Register();
		}
	}
}