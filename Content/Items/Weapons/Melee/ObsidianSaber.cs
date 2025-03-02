using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Tiles;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class ObsidianSaber : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Arkhalis);
			Item.shootSpeed *= 0.75f;
			Item.damage = 41;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Obsidian Saber");
			//Tooltip.SetDefault("");
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<ObsidianSaberPro>(), damage, knockback, player.whoAmI);
            return false;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Obsidian, 100);
			recipe.AddIngredient(ItemID.SoulofNight, 15);
			recipe.AddIngredient(ItemID.SoulofLight, 15);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<GreatAnvilTile>());
			recipe.Register();
		}
	}
}
