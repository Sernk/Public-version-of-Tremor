using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class TrueTerraBlade : ModItem
	{
		public override void SetDefaults()
		{
			Item.rare = 10;
			Item.UseSound = SoundID.Item1;

			Item.useStyle = 1;
			Item.damage = 196;
			Item.useAnimation = 16;
			Item.useTime = 14;
			Item.width = 84;
			Item.height = 84;
			Item.shoot = 132;
			Item.scale = 1.1f;
			Item.shootSpeed = 15f;
			Item.knockBack = 6.5f;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.value = Item.sellPrice(0, 20, 0, 0);
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("True Terra Blade");
			// Tooltip.SetDefault("'Shining, shimmering, splendid!'");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TerraBlade, 1);
			recipe.AddIngredient(ModContent.ItemType<NightmareBar>(), 25);
			recipe.AddIngredient(ModContent.ItemType<SeaFragment>(), 30);
			recipe.AddIngredient(ModContent.ItemType<EarthFragment>(), 30);
			recipe.AddIngredient(ModContent.ItemType<FireFragment>(), 30);
			recipe.AddIngredient(ModContent.ItemType<AirFragment>(), 30);
			recipe.AddTile(412);
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
