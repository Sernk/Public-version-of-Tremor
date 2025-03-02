using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class TrueBeamSword : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 92;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 50;
			Item.height = 52;
			Item.useTime = 45;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.shoot = 116;
			Item.shootSpeed = 15f;
			Item.knockBack = 8;

			Item.value = 750000;
			Item.rare = 6;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("True Beam Sword");
			// Tooltip.SetDefault("Shoots a beam of light");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.EnchantedSword, 1);
			recipe.AddIngredient(ItemID.BeamSword, 1);
			recipe.AddIngredient(ModContent.ItemType<MagiumShard>(), 25);
			recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
