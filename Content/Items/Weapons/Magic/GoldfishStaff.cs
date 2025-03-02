using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class GoldfishStaff : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Starfury);
			Item.damage = 10;
			//Item.melee = false;
			Item.DamageType = DamageClass.Magic;
			Item.width = 50;
			Item.height = 55;
			Item.useTime = 20;
			Item.mana = 9;
			Item.useAnimation = 50;
			Item.useStyle = 5;
			Item.shootSpeed = 10f;
			Item.staff[Item.type] = true;
			Item.knockBack = 3;
			Item.value = 10000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item9;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Goldfish Staff");
			//Tooltip.SetDefault("Causes goldfishes to fall from the sky");
		}

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<GoldFishPro>(), damage, knockback, player.whoAmI);
            return false; 
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 16);
			recipe.AddIngredient(ItemID.IronBar, 6);
			recipe.AddIngredient(ItemID.Goldfish, 3);
			recipe.AddTile(18);
			//recipe.SetResult(this);
			recipe.Register();

			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ItemID.Wood, 16);
			recipe1.AddIngredient(ItemID.LeadBar, 6);
			recipe1.AddIngredient(ItemID.Goldfish, 3);
			recipe1.AddTile(18);
			//recipe1.SetResult(this);
			recipe1.Register();
		}
	}
}
