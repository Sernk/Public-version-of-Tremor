using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class RoyalStrike : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 189;
			Item.DamageType = DamageClass.Melee;
			Item.width = 30;
			Item.height = 38;
			Item.useTime = 26;
			Item.useAnimation = 26;
			Item.useStyle = 1;
			Item.knockBack = 7;
			Item.shoot = 160;
			Item.shootSpeed = 14f;
			Item.value = 150000;
			Item.rare = 11;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Royal Strike");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Sapphire, 8);
			recipe.AddIngredient(ItemID.GoldBar, 15);
			recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 6);
			recipe.AddIngredient(ModContent.ItemType<EvershinyBar>(), 12);
			//recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.Register();
		}
	}
}