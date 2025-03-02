using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class Permafrost : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 123;
			Item.DamageType = DamageClass.Melee;
			Item.width = 38;
			Item.height = 20;
			Item.useTime = 20;
			Item.useAnimation = 34;
			Item.useStyle = 1;
			Item.knockBack = 10;
			Item.value = 160000;
			Item.rare = 10;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = 263;
			Item.shootSpeed = 10f;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Permafrost");
			//Tooltip.SetDefault("");
		}

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < 1; ++i)
            {
                Projectile.NewProjectile(source, position, velocity + new Vector2(1, 1), type, damage, knockback, Main.myPlayer);
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer);
                Projectile.NewProjectile(source, position, velocity - new Vector2(-1, -1), type, damage, knockback, Main.myPlayer);
            }
            return false;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<FrostoneBar>(), 10);
			recipe.AddIngredient(ModContent.ItemType<IceSoul>(), 12);
			//recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.Register();
		}
	}
}
