using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class Squasher : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 88;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 56;
			Item.height = 56;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 122000;
			Item.rare = 3;
			Item.UseSound = SoundID.Item1;

			Item.hammer = 100;
			Item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Squasher");
			// Tooltip.SetDefault("Strong enough to destroy Demon Altars");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Pwnhammer, 1);
			recipe.AddIngredient(ModContent.ItemType<DarkBulb>(), 15);
			recipe.AddIngredient(ItemID.Bone, 100);
			//recipe.SetResult(this, 1);
			recipe.AddTile(134);
			recipe.Register();

			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ModContent.ItemType<Doomhammer>(), 1);
			recipe1.AddIngredient(ModContent.ItemType<DarkBulb>(), 15);
			recipe1.AddIngredient(ItemID.Bone, 100);
			//recipe.SetResult(this, 1);
			recipe1.AddTile(134);
			recipe1.Register();
		}
	}
}
