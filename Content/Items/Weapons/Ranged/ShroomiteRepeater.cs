using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class ShroomiteRepeater : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 36;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 62;
			Item.height = 30;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 6;
			Item.value = 50000;
			Item.rare = 6;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 8;
			Item.shootSpeed = 30f;
			Item.useAmmo = AmmoID.Arrow;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Shroomite Repeater");
			// Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ShroomiteBar, 16);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
