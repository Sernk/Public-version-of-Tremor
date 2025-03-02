using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class SpineBlade : ModItem
	{
		public override void SetDefaults()
		{

			Item.useStyle = 1;
			Item.useAnimation = 28;
			Item.useTime = 28;
			Item.knockBack = 5.75f;
			Item.width = 40;
			Item.height = 40;
			Item.damage = 165;
			Item.scale = 1.125f;
			Item.shootSpeed = 15f;
			Item.shoot = 524;
			Item.UseSound = SoundID.Item1;
			Item.rare = 9;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(0, 5, 0, 0);
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Spine Blade");
			// Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Bladetongue, 1);
			recipe.AddIngredient(ModContent.ItemType<NightmareBar>(), 15);
			recipe.AddIngredient(ItemID.CrimtaneBar, 25);
			recipe.AddIngredient(ModContent.ItemType<Doomstone>(), 6);
			recipe.AddIngredient(ModContent.ItemType<Phantaplasm>(), 10);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
