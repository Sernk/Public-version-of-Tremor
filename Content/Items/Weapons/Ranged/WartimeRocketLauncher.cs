using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class WartimeRocketLauncher : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 220;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 58;
			Item.height = 34;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.shoot = 134;
			Item.shootSpeed = 10f;
			Item.useAmmo = AmmoID.Rocket;
			Item.useStyle = 5;
			Item.knockBack = 4;
			Item.value = 750000;
			Item.rare = 11;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Wartime Rocket Launcher");
			// Tooltip.SetDefault("");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-14, -2);
		}
	}
}
