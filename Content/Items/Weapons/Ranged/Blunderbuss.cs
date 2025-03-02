using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class Blunderbuss : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 32;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.shoot = 14;
			Item.shootSpeed = 8f;
			Item.useAmmo = AmmoID.Bullet;
			Item.useStyle = 5;
			Item.knockBack = 4;
			Item.value = 60000;
			Item.rare = 5;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Blunderbuss");
			//Tooltip.SetDefault("");
		}
	}
}