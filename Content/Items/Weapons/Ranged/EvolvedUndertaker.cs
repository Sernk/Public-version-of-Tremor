using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class EvolvedUndertaker : ModItem
	{
		public override void SetDefaults()
		{
			Item.useStyle = 5;
			Item.autoReuse = true;
			Item.useAnimation = 36;
			Item.useTime = 36;
			Item.width = 44;
			Item.height = 14;
			Item.shoot = 10;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item11;
			Item.damage = 344;
			Item.shootSpeed = 9f;
			Item.noMelee = true;
			Item.value = 100000;
			Item.knockBack = 5.25f;
			Item.rare = 11;
			Item.DamageType =DamageClass.Ranged;
			Item.crit = 7;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Evolved Undertaker");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TheUndertaker, 1);
			recipe.AddIngredient(ModContent.ItemType<WhiteGoldBar>(), 12);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<DivineForgeTile>());
			recipe.Register();
		}
	}
}
