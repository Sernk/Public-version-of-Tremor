using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class TrueArachnophobia : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 49;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 66;
			Item.height = 66;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.useStyle = 1;
			Item.knockBack = 7;
			Item.shoot = 379;
			Item.shootSpeed = 17f;
			Item.value = 12500;
			Item.rare = 8;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("True Arachnophobia");
			// Tooltip.SetDefault("");
		}

		public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			for (int i = 0; i < 1; ++i)
			{
				Projectile.NewProjectile(source, position, velocity + new Vector2(2, 2), type, damage, knockback, Main.myPlayer);
				Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer);
				Projectile.NewProjectile(source, position, velocity - new Vector2(2, 2), type, damage, knockback, Main.myPlayer);
			}
			return false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Arachnophobia>(), 1);
			recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
