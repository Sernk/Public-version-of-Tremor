using TremorMod.Content.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Tools
{

	public class AmethystDrill : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 9;
            Item.DamageType = DamageClass.Melee;
            Item.width = 20;
			Item.height = 12;
			Item.useTime = 8;
			Item.useAnimation = 25;
			Item.channel = true;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.pick = 85;
			Item.useStyle = 5;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(0, 0, 50, 0);
			Item.rare = 2;
			Item.UseSound = SoundID.Item23;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<AmethystDrillPro>();
            Item.shootSpeed = 40f;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Amethyst Drill");
			Tooltip.SetDefault("");
		}*/

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Obsidian, 25);
			recipe.AddIngredient(ItemID.MeteoriteBar, 16);
			recipe.AddIngredient(ItemID.Amethyst, 12);
			//recipe.SetResult(this);
			recipe.AddTile(16);
            recipe.Register();
        }
	}
}
