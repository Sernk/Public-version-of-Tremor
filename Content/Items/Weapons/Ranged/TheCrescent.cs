using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class TheCrescent : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 275;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 16;
			Item.height = 32;
			Item.useTime = 5;
			Item.shoot = 1;
			Item.shootSpeed = 11f;
			Item.useAnimation = 25;
			Item.useStyle = 5;
			Item.knockBack = 1;
			Item.value = 10000;
			Item.useAmmo = AmmoID.Arrow;
			Item.rare = 1;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("The Crescent");
			// Tooltip.SetDefault("");
		}

		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextBool(2);
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-12, -2);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<WhiteGoldBar>(), 15);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<DivineForgeTile>());
			recipe.Register();
		}
	}
}
