using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class OrichalcumStaff : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 30;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 8;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 38;
			Item.useAnimation = 38;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = 18440;
			Item.rare = 4;
			Item.UseSound = SoundID.Item91;
			Item.autoReuse = true;
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
			Item.shoot = ModContent.ProjectileType<OrichalcumBolt>();
			Item.shootSpeed = 15f;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Orichalcum Staff");
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
			recipe.AddIngredient(ItemID.OrichalcumBar, 12);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
