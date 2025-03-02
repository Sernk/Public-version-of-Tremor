using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Ranged.Ammo
{
	public class NightmareBullet : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 1.5f;
			Item.value = 10;
			Item.rare = 11;
			Item.shoot = ModContent.ProjectileType<NightmareBulletPro>();
			Item.shootSpeed = 10f;
			Item.ammo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Nightmare Bullet");
			//Tooltip.SetDefault("'Can bounce off blocks.'");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(50);
			recipe.AddIngredient(ItemID.EmptyBullet, 50);
			recipe.AddIngredient(ModContent.ItemType<NightmareBar>(), 1);
			recipe.AddTile(412);
			//recipe.SetResult(this, 50);
			recipe.Register();
		}
	}
}
