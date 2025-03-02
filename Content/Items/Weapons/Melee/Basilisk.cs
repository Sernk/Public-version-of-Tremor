using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class Basilisk : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 68;
			Item.DamageType = DamageClass.Melee;
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.useStyle = 1;
			Item.knockBack = 7;
			Item.value = 32740;
			Item.rare = 6;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = 606;
			Item.shootSpeed = 30f;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Basilisk");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SkullTeeth>(), 5);
			recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 10);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}

	}
}
