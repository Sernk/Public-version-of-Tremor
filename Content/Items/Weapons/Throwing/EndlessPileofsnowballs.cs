using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Throwing
{
	public class EndlessPileofsnowballs : ModItem
	{
		public override void SetDefaults()
		{
			Item.useStyle = 1;
			Item.shootSpeed = 7f;
			Item.shoot = 166;
			Item.damage = 8;
			Item.width = 18;
			Item.height = 20;
			Item.maxStack = 1;
			Item.ammo = 949;
			Item.rare = 2;
			Item.consumable = false;
			Item.UseSound = SoundID.Item1;
			Item.useAnimation = 19;
			Item.useTime = 19;
			Item.noUseGraphic = true;
			//item.noMelee = true;
			Item.DamageType = DamageClass.Throwing;
			Item.knockBack = 5.75f;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Endless Pile of snowballs");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Snowball, 3996);
			//recipe.SetResult(this);
			recipe.AddTile(125);
			recipe.Register();
		}
	}
}