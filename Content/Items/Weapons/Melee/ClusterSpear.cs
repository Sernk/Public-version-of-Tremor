using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class ClusterSpear : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 295;
			Item.width = 70;
			Item.height = 70;
			Item.noUseGraphic = true;
			Item.DamageType = DamageClass.Melee;
			Item.useTime = 16;
			Item.shoot = ModContent.ProjectileType<ClusterSpearPro>();
			Item.shootSpeed = 5f;
			Item.useAnimation = 30;
			Item.useStyle = 5;
			Item.knockBack = 4;
			Item.value = 512500;
			Item.rare = 11;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Cluster Spear");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<EyeofOblivion>(), 1);
			recipe.AddIngredient(ModContent.ItemType<CarbonSteel>(), 12);
			recipe.AddIngredient(ModContent.ItemType<ToothofAbraxas>(), 15);
			recipe.AddIngredient(ModContent.ItemType<ClusterShard>(), 25);
			recipe.AddTile(412);
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
