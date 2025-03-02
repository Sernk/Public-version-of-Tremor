using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class Earthquake : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 41;
			Item.DamageType = DamageClass.Magic;
			Item.width = 28;
			Item.height = 30;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.shootSpeed = 15f;
			Item.mana = 8;
			Item.useStyle = 5;
			Item.shoot = ModContent.ProjectileType<EarthquakePro>();
			Item.knockBack = 3;
			Item.value = 10000;
			Item.rare = 5;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Earthquake");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SpellTome, 1);
			recipe.AddIngredient(ItemID.MudBlock, 25);
			recipe.AddIngredient(ModContent.ItemType<EarthFragment>(), 14);
			recipe.AddIngredient(ModContent.ItemType<SeaFragment>(), 10);
			//recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.Register();
		}
	}
}