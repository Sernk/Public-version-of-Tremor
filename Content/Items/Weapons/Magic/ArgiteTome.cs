using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class ArgiteTome : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 18;
			//Item.melee = false;
			Item.DamageType = DamageClass.Magic;
			Item.width = 50;
			Item.height = 55;
			Item.useTime = 30;
			Item.mana = 8;
			Item.useAnimation = 30;
			Item.useStyle = 5;
			Item.shoot = ModContent.ProjectileType<ArgiteSpherePro>();
			Item.shootSpeed = 12f;
			Item.knockBack = 4;
			Item.value = 32000;
			Item.rare = 3;
			Item.UseSound = SoundID.Item9;
			Item.autoReuse = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Argite Tome");
			Tooltip.SetDefault("");
		}*/

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Book, 1);
			recipe.AddIngredient(ModContent.ItemType<ArgiteBar>(), 20);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<MagicWorkbenchTile>());
			recipe.Register();
		}
	}
}
