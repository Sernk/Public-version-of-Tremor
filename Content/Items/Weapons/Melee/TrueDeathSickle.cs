using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class TrueDeathSickle : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 71;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 120;
			Item.height = 112;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.channel = true;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.useTurn = true;
			Item.useStyle = 100;
			Item.knockBack = 8f;
			Item.value = Item.sellPrice(0, 10, 0, 0);
			Item.rare = 8;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<TrueDeathSickleProj>();
			Item.shootSpeed = 0f;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("True Death Sickle");
			// Tooltip.SetDefault("");
		}

		public override void UseItemFrame(Player player)
		{
			player.bodyFrame.Y = 3 * player.bodyFrame.Height;
			return;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(1327);
			recipe.AddIngredient(1570);
			recipe.AddIngredient(548, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			//recipe.SetResult(this, 1);
			recipe.Register();
		}
	}
}
