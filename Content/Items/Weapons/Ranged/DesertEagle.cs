using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class DesertEagle : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 56;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 52;
			Item.height = 34;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.shoot = 14;
			Item.shootSpeed = 15f;
			Item.useAmmo = AmmoID.Bullet;
			Item.useStyle = 5;
			Item.knockBack = 4;
			Item.value = 150000;
			Item.rare = 5;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Desert Eagle");
			// Tooltip.SetDefault("");
		}

	}
}
