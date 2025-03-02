using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class Sharanga : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 24;
			Item.width = 16;
			Item.height = 32;
			Item.DamageType = DamageClass.Ranged;
			Item.useTime = 20;
			Item.shoot = 1;
			Item.shootSpeed = 12f;
			Item.useAnimation = 20;
			Item.useStyle = 5;
			Item.knockBack = 5;
			Item.value = 8340;
			Item.useAmmo = AmmoID.Arrow;
			Item.rare = 3;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Sharanga");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ShadowBow>(), 1);
			recipe.AddIngredient(ItemID.Obsidian, 15);
			recipe.AddIngredient(ModContent.ItemType<DemonBlood>(), 8);
			recipe.AddIngredient(ModContent.ItemType<MinotaurHorn>(), 2);
			recipe.AddTile(ModContent.TileType<DevilForgeTile>());
			//recipe.SetResult(this);
			recipe.Register();
		}
	}
}
