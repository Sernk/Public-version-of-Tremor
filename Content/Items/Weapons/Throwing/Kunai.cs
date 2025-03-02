using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Throwing
{
	public class Kunai : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 14;
			Item.height = 32;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 18;
			Item.noUseGraphic = true;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.useTime = 19;
			Item.useAnimation = 19;
			Item.shoot = ModContent.ProjectileType<KunaiPro>();
			Item.shootSpeed = 15f;
			Item.useStyle = 1;
			Item.knockBack = 4;
			Item.value = 60;
			Item.rare = 1;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Kunai");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 3);
			recipe.AddIngredient(ItemID.IronBar, 4);
			//recipe.SetResult(this, 50);
			recipe.Register();

			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ItemID.Wood, 3);
			recipe1.AddIngredient(ItemID.LeadBar, 4);
			recipe1.Register();
		}
	}
}
