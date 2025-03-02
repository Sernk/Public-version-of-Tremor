using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class CandyBlaster : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 226;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 42;
			Item.height = 30;

			Item.useTime = 4;
			Item.useAnimation = 12;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 4f;
			Item.value = Item.sellPrice(0, 20, 0, 0);
			Item.rare = 10;
			Item.UseSound = SoundID.Item40;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 15f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Candy Blaster");
			// Tooltip.SetDefault("Spends bullets and fires candies");
		}

		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextBool(3);
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<SweetPro>(), damage, knockback, player.whoAmI);
            return false; // ¬озвращаем false, чтобы не создавать стандартный снар€д
        }

        public override Vector2? HoldoutOffset()
		{
			return Vector2.Zero;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SoulofLight, 20);
			recipe.AddIngredient(ItemID.SoulofNight, 20);
			recipe.AddIngredient(ModContent.ItemType<CarbonSteel>(), 8);
			recipe.AddIngredient(ModContent.ItemType<CandyBar>(), 12);
			recipe.AddTile(412);
			recipe.Register();
		}
	}
}
