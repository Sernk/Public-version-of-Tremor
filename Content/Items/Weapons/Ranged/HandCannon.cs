using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class HandCannon : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 60;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 58;
			Item.height = 30;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 6;
			Item.value = 50000;
			Item.rare = 5;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 162;
			Item.shootSpeed = 15f;
			//item.useAmmo = 14;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Hand Cannon");
			//Tooltip.SetDefault("");
		}
	}
}