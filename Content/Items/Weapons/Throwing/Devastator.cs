using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Throwing
{
	public class Devastator : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 162;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 26;
			Item.noUseGraphic = true;
			Item.maxStack = 1;
			Item.height = 30;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.shoot = ModContent.ProjectileType<DevastatorPro>();
			Item.shootSpeed = 19f;
			Item.useStyle = 1;
			Item.knockBack = 4;
			Item.value = 70000;
			Item.rare = 11;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Devastator");
			//Tooltip.SetDefault("");
		}

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < 1; ++i)
            {
                Projectile.NewProjectile(source, position, velocity + new Vector2(2, 2), type, damage, knockback, Main.myPlayer);
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer);
                Projectile.NewProjectile(source, position, velocity - new Vector2(2, 2), type, damage, knockback, Main.myPlayer);
            }
            return false;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<VoidBar>(), 20);
			recipe.AddIngredient(ModContent.ItemType<Doomstone>(), 10);
			recipe.AddIngredient(ModContent.ItemType<DarkMatter>(), 100);
			//recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.Register();
		}
	}
}