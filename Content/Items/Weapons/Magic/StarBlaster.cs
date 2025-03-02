using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class StarBlaster : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 110;
			Item.DamageType = DamageClass.Magic;
			Item.width = 68;
			Item.height = 28;
			Item.useTime = 6;
			Item.useAnimation = 30;
			Item.mana = 5;
			Item.shoot = 503;
			Item.shootSpeed = 12f;
			Item.useStyle = 5;
			Item.knockBack = 4;
			Item.value = 300000;
			Item.rare = 10;
			Item.UseSound = SoundID.Item114;
			Item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Star Blaster");
			// Tooltip.SetDefault("");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-18, -4);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<StarBar>(), 20);
			recipe.AddIngredient(ModContent.ItemType<Phantaplasm>(), 6);
			recipe.AddIngredient(ModContent.ItemType<CarbonSteel>(), 6);
			recipe.AddIngredient(ItemID.MartianConduitPlating, 50);
			//recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.Register();
		}
	}
}
