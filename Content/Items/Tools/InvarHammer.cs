using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;

namespace TremorMod.Content.Items.Tools
{
	public class InvarHammer : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 7;
            Item.DamageType = DamageClass.Melee;
            Item.width = 36;
			Item.height = 36;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.hammer = 40;
			Item.useStyle = 1;
			Item.knockBack = 3;
			Item.value = 100;
			Item.rare = 1;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Invar Hammer");
			Tooltip.SetDefault("");
		}*/

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<InvarBar>(), 10);
            recipe.AddIngredient(ItemID.Wood, 3);
			recipe.AddTile(16);
			//recipe.SetResult(this);
            recipe.Register();
        }
	}
}
