using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class RavenClutches : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 29;
			Item.DamageType = DamageClass.Melee;
			Item.width = 28;
			Item.height = 18;
			Item.useTime = 9;
			Item.useAnimation = 9;
			Item.useStyle = 1;
			Item.knockBack = 3;
			Item.value = 6400;
			Item.rare = 4;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Raven Clutches");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SilverBar, 10);
			recipe.AddIngredient(ModContent.ItemType<Opal>(), 1);
			recipe.AddIngredient(ModContent.ItemType<RavenFeather>(), 13);
			//recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.Register();

			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ItemID.TungstenBar, 10);
            recipe1.AddIngredient(ModContent.ItemType<Opal>(), 1);
            recipe1.AddIngredient(ModContent.ItemType<RavenFeather>(), 13);
            //recipe.SetResult(this);
			recipe1.AddTile(16);
			recipe1.Register();
		}
	}
}
