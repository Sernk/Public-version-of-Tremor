using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class Darkhalis : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Arkhalis);
			Item.damage = 90;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Darkhalis");
			// Tooltip.SetDefault("'It came from the deep abyss...'");
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			type = ModContent.ProjectileType<DarkhalisPro>();
			return false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Arkhalis, 1);
			recipe.AddIngredient(ModContent.ItemType<NightmareBar>(), 22);
			recipe.AddIngredient(ModContent.ItemType<Doomstone>(), 15);
			recipe.AddIngredient(ModContent.ItemType<Phantaplasm>(), 12);
			recipe.AddTile(412);
			recipe.Register();
		}
	}
}
