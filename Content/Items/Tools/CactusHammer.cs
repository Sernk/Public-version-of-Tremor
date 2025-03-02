using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Tools
{
	public class CactusHammer : ModItem
	{
		public override void SetDefaults()
		{
			Item.autoReuse = true;
			Item.useStyle = 1;
			Item.useTurn = true;
			Item.useAnimation = 30;
			Item.useTime = 20;
			Item.hammer = 38;
			Item.width = 24;
			Item.height = 28;
			Item.damage = 9;
			Item.knockBack = 5.5f;
			Item.scale = 1.2f;
			Item.UseSound = SoundID.Item1;
			Item.value = 1600;
			Item.DamageType = DamageClass.Melee;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Cactus Hammer");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Cactus, 16);
			recipe.AddTile(16);
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
