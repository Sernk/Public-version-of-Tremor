using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class Sharkhalis : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Arkhalis);
			Item.damage = 30;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Sharkhalis");
			//Tooltip.SetDefault("");
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<SharkhalisPro>(), damage, knockback, player.whoAmI);
			return false;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Arkhalis, 1);
			recipe.AddIngredient(ItemID.SharkFin, 3);
			recipe.AddIngredient(ModContent.ItemType<SharpenedTooth>(), 6);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<AltarofEnchantmentsTile>());
			recipe.Register();
		}
	}
}
