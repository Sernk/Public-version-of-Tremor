using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;

namespace TremorMod.Content.Items.Tools
{
	public class InvarAxe : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 5;
			Item.DamageType = DamageClass.Melee;
			Item.width = 36;
			Item.height = 36;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.axe = 9;
			Item.useStyle = 1;
			Item.knockBack = 3;
			Item.value = 100;
			Item.rare = 1;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Invar Axe");
			Tooltip.SetDefault("");
		}*/

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<InvarBar>(), 18);
            recipe.AddIngredient(ItemID.Wood, 3);
			recipe.AddTile(16);
			//recipe.SetResult(this);
            recipe.Register();
        }
	}
}
