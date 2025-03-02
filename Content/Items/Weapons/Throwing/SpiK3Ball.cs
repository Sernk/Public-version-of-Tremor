using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Throwing
{
	public class SpiK3Ball : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 38;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 18;
			Item.height = 18;
			Item.maxStack = 999;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.shoot = ModContent.ProjectileType<SpiK3BallPro>();
			Item.shootSpeed = 7f;
			Item.useStyle = 1;
			Item.knockBack = 3;
			Item.value = 155;
			Item.rare = 8;
			Item.consumable = true;
			Item.UseSound = SoundID.Item1;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("SpiK-3 Ball");
			// Tooltip.SetDefault("");
		}

	}
}
