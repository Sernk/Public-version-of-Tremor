using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class RupicideRepeater : ModItem
	{
		public override void SetDefaults()
		{

			Item.DamageType = DamageClass.Ranged;
			Item.width = 36;
			Item.height = 24;

			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.shoot = 1;
			Item.useAmmo = AmmoID.Arrow;
			Item.shootSpeed = 30f;
			Item.useStyle = 5;
			Item.damage = 26;
			Item.knockBack = 4;
			Item.value = 30000;
			Item.rare = 5;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Rupicide Repeater");
			/* Tooltip.SetDefault("Quickly launches arrows\n" +
	  "20% to shoot a fiery burst"); */
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<BowBlueprint>(), 1);
			recipe.AddIngredient(ModContent.ItemType<RupicideBar>(), 8);
			recipe.AddIngredient(ModContent.ItemType<RuneBar>(), 8);
			recipe.AddIngredient(ModContent.ItemType<CryptStone>(), 3);
			recipe.AddTile(ModContent.TileType<NecromaniacWorkbenchTile>());
			recipe.Register();
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-18, -4);
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			type = 1;

			if (Main.rand.NextBool(5))
			{
				int proj = Projectile.NewProjectile(Item.GetSource_FromThis(), position.X, position.Y, velocity.X, velocity.Y, 686, damage, Main.myPlayer);
				Main.projectile[proj].hostile = false;
				Main.projectile[proj].friendly = true;
				return false;
			}

			return false;
		}
	}
}
