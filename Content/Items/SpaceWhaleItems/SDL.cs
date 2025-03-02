using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.SpaceWhaleItems
{
	public class SDL : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 70;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.shoot = 135;
			Item.shootSpeed = 25f;
			Item.useAmmo = AmmoID.Rocket;
			Item.useStyle = 5;
			Item.knockBack = 4;
			Item.value = 60000;
			Item.rare = 11;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("S.D.L.");
			//Tooltip.SetDefault("Uses rockets as ammo");
		}
	}
}