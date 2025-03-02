using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Throwing
{
	public class EaterofWorld : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 139;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 40;
			Item.height = 20;
			Item.noUseGraphic = true;
			Item.useTime = 30;
			Item.useAnimation = 20;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 6;
			Item.value = 50000;
			Item.rare = 9;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 306;
			Item.shootSpeed = 9f;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Eater of World");
			//Tooltip.SetDefault("");
		}

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < 1; ++i)
            {
                Projectile.NewProjectile(source, position, velocity + new Vector2(1, 1), type, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity + new Vector2(-1, -1), type, damage, knockback, player.whoAmI);
            }
            return false;
        }



        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<NightmareBar>(), 15);
			recipe.AddIngredient(ModContent.ItemType<PurpleQuartz>(), 6);
			recipe.AddIngredient(ItemID.DemoniteBar, 25);
			recipe.AddIngredient(ModContent.ItemType<Doomstone>(), 6);
			recipe.AddIngredient(ModContent.ItemType<Phantaplasm>(), 10);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}