using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class InvarBow : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 9;
			Item.width = 16;
			Item.height = 32;
			Item.useTime = 30;
		    Item.DamageType = DamageClass.Ranged;
			Item.shoot = 1;
			Item.shootSpeed = 12f;
			Item.useAnimation = 28;
			Item.useStyle = 5;
			Item.useTime = 28;
			Item.knockBack = 5;
			Item.value = 250;
			Item.useAmmo = AmmoID.Arrow;
			Item.rare = 1;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = false;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Invar Bow");
			Tooltip.SetDefault("");
		}*/

		public override void AddRecipes()
		{
		    Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<InvarBar>(), 7);
			recipe.AddTile(16);
		    //recipe.SetResult(this);
			recipe.Register();
		}
	}
}
