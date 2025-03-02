using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class WaterDeadShot : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 14;
			Item.width = 18;
			Item.height = 48;
			Item.useTime = 30;
			Item.DamageType = DamageClass.Ranged;
			Item.shoot = 27;

			Item.shootSpeed = 23f;
			Item.useAnimation = 30;
			Item.useStyle = 5;
			Item.knockBack = 5;
			Item.value = 250;
			Item.useAmmo = AmmoID.Arrow;
			Item.rare = 2;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Water Dead Shot");
			/* Tooltip.SetDefault("Shoots water streams\n" +
"Uses arrows as ammo"); */
		}

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            type = ProjectileID.WaterBolt;
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
            return false;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SeaFragment>(), 8);
			recipe.AddIngredient(ItemID.Sapphire, 10);
			recipe.AddIngredient(ItemID.GoldBar, 6);
			recipe.AddTile(16);
			//recipe.SetResult(this);
			recipe.Register();

			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ModContent.ItemType<SeaFragment>(), 8);
			recipe1.AddIngredient(ItemID.Sapphire, 10);
			recipe1.AddIngredient(ItemID.PlatinumBar, 6);
			recipe1.AddTile(16);
			//recipe.SetResult(this);
			recipe1.Register();
		}
	}
}
