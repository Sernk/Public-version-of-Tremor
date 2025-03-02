using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class ShroomiteRocketLauncher : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 64;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 66;
			Item.height = 32;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.shoot = 134;
			Item.shootSpeed = 10f;
			Item.useAmmo = AmmoID.Rocket;
			Item.useStyle = 5;
			Item.knockBack = 4;
			Item.value = 60000;
			Item.rare = 8;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Shroomite Rocket Launcher");
			// Tooltip.SetDefault("");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-18, -4);
		}

		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextBool(3);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ShroomiteBar, 16);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
