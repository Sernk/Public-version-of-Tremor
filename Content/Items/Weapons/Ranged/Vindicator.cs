using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class Vindicator : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Vindicator");
			// Tooltip.SetDefault("");
		}

		public override void SetDefaults()
		{
			Item.damage = 200;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 76;
			Item.height = 26;
			Item.useTime = 9;
			Item.useAnimation = 9;
			Item.channel = true;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.useStyle = 5;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(15, 00);
			Item.rare = 11;
			//item.UseSound = SoundID.Item23;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<VindicatorProj>();
			Item.shootSpeed = 45f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<CarbonSteel>(), 15);
			recipe.AddIngredient(ModContent.ItemType<NightmareBar>(), 18);
			recipe.AddIngredient(ItemID.IllegalGunParts, 3);
			recipe.AddIngredient(ItemID.LaserMachinegun, 1);
			recipe.AddIngredient(ItemID.SoulofNight, 8);
			recipe.AddIngredient(ModContent.ItemType<MultidimensionalFragment>(), 9);
			//recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.Register();
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-12, -7);
		}

		//public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		//{
			//Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, 0.0f, 0.0f);
			//return false;
		//}
	}
}