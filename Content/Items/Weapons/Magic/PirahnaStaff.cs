using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class PirahnaStaff : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Starfury);
			Item.damage = 18;
			//Item.melee = false;
			Item.DamageType = DamageClass.Magic;
			Item.width = 50;
			Item.height = 55;
			Item.useTime = 20;
			Item.mana = 8;
			Item.useAnimation = 50;
			Item.useStyle = 5;
			Item.shootSpeed = 10f;
			Item.staff[Item.type] = true;
			Item.knockBack = 3;
			Item.value = 15000;
			Item.rare = 3;
			Item.UseSound = SoundID.Item9;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Piranha Staff");
			//Tooltip.SetDefault("Causes pirahnas to fall from the sky");
		}

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<PirahnaPro>(), damage, knockback, player.whoAmI);
			return false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<GoldfishStaff>(), 1);
			recipe.AddIngredient(ModContent.ItemType<SeaFragment>(), 10);
			recipe.AddIngredient(ItemID.GoldBar, 8);
			recipe.AddIngredient(ItemID.Ruby, 6);
			recipe.AddTile(ModContent.TileType<MagicWorkbenchTile>());
			//recipe.SetResult(this);
			recipe.Register();

			Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ModContent.ItemType<GoldfishStaff>(), 1);
            recipe1.AddIngredient(ModContent.ItemType<SeaFragment>(), 10);
            recipe1.AddIngredient(ItemID.PlatinumBar, 8);
			recipe1.AddIngredient(ItemID.Ruby, 6);
            recipe1.AddTile(ModContent.TileType<MagicWorkbenchTile>());
            //recipe.SetResult(this);
			recipe1.Register();
		}
	}
}
