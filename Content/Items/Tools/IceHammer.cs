using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Tools
{
	public class IceHammer : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 72;
			Item.DamageType = DamageClass.Melee;
			Item.width = 36;
			Item.height = 36;
			Item.useTime = 5;
			Item.useAnimation = 16;
			Item.hammer = 100;
			Item.useStyle = 1;
			Item.knockBack = 5;
			Item.value = 200000;
			Item.rare = 7;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Ice Hammer");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<FrostoneBar>(), 10);
			recipe.AddTile(134);
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}