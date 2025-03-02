using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class HallowedSpray : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 56;
			Item.DamageType = DamageClass.Magic;
			Item.width = 28;
			Item.height = 30;
			Item.useTime = 10;
			Item.useAnimation = 30;
			Item.shoot = ModContent.ProjectileType<HallowedSprayPro>();
			Item.shootSpeed = 7.5f;
			Item.mana = 6;
			Item.noMelee = true;
			Item.useStyle = 5;
			Item.knockBack = 3;
			Item.value = 99999;
			Item.rare = 5;
			Item.UseSound = SoundID.Item21;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Hallowed Spray");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SpellTome, 1);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			//recipe.SetResult(this);
			recipe.AddTile(101);
			recipe.Register();
		}
	}
}
