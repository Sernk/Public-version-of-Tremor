using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Throwing
{
	public class FrostJavelin : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 12;
			Item.width = 14;
			Item.height = 84;
			Item.noUseGraphic = true;
			Item.DamageType = DamageClass.Throwing;
			Item.useTime = 30;
			Item.shoot = ModContent.ProjectileType<FrostJavelinPro>();
			Item.shootSpeed = 15f;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.knockBack = 4;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.value = 10;
			Item.rare = 1;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Frost Javelin");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<FrostCore>(), 1);
			//recipe.SetResult(this, 25);
			recipe.AddTile(16);
			recipe.Register();
		}
	}
}
