using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class GrossBow : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 23;
			Item.width = 18;
			Item.height = 56;
			Item.DamageType = DamageClass.Ranged;
			Item.useTime = 30;
			Item.shoot = 1;
			Item.shootSpeed = 12f;
			Item.useAnimation = 30;
			Item.useStyle = 5;
			Item.knockBack = 5;
			Item.value = 25000;
			Item.useAmmo = AmmoID.Arrow;
			Item.rare = 3;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Gross Bow");
			//Tooltip.SetDefault("");
		}

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<DemonEyePro>(), damage, knockback, player.whoAmI);
            return false;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(this.Type);
			recipe.AddIngredient(ItemID.DemoniteBar, 5);
			recipe.AddIngredient(ModContent.ItemType<DrippingRoot>(), 12);
			recipe.AddIngredient(ItemID.Lens, 6);
			recipe.AddTile(16);
			recipe.Register();

			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ItemID.CrimtaneBar, 5);
			recipe1.AddIngredient(ModContent.ItemType<DrippingRoot>(), 12);
			recipe1.AddIngredient(ItemID.Lens, 6);
			recipe1.AddTile(16);
			//recipe1.SetResult(this);
			recipe1.Register();
		}
	}
}
