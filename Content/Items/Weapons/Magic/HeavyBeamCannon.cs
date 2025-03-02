using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class HeavyBeamCannon : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 52;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 9;
			Item.width = 42;
			Item.height = 30;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 4f;
			Item.value = Item.sellPrice(0, 10, 0, 0);
			Item.rare = 7;
			Item.channel = true;
			Item.UseSound = SoundID.Item12;
			Item.autoReuse = false;
			Item.shootSpeed = 25f;
			Item.shoot = ModContent.ProjectileType<ExampleLaser>();
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Heavy Beam Cannon");
			//Tooltip.SetDefault("Fires a constant powerful beam");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, -1);
		}

	}
}
