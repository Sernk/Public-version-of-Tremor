using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class OceanBate : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 168;
			Item.DamageType = DamageClass.Ranged;
			//Item.melee = false;
			Item.width = 28;
			Item.height = 52;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useAmmo = AmmoID.Arrow;
			Item.useStyle = 5;
			Item.shootSpeed = 30f;
			Item.knockBack = 3;
			Item.value = 85000;
			Item.rare = 10;
			Item.shoot = 408;
			Item.shootSpeed = 19f;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Ocean Bate");
			//Tooltip.SetDefault("");
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
            Projectile.NewProjectile(source, position, velocity, ProjectileID.MiniSharkron, damage, knockback, player.whoAmI); 
            return false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SeaFragment>(), 25);
			recipe.AddIngredient(ItemID.Coral, 20);
			recipe.AddIngredient(ItemID.SharkFin, 8);
			recipe.AddIngredient(ModContent.ItemType<ConcentratedEther>(), 25);
			//recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.Register();
		}
	}
}