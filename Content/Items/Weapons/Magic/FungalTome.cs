using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class FungalTome : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 24;
			//item.melee = false;
			Item.DamageType = DamageClass.Magic;
			Item.width = 50;
			Item.height = 55;
			Item.useTime = 15;
			Item.mana = 7;
			Item.useAnimation = 15;
			Item.useStyle = 5;
			Item.shoot = 131;
			Item.shootSpeed = 20f;
			Item.knockBack = 4;
			Item.value = 50000;
			Item.rare = 3;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Fungal Tome");
			//Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Book, 1);
			recipe.AddIngredient(ItemID.GlowingMushroom, 15);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<MagicWorkbenchTile>());
			recipe.Register();
		}
	}
}