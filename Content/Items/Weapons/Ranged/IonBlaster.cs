using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class IonBlaster : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 68;
			Item.height = 28;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.shoot = 440;
			Item.shootSpeed = 14f;
			Item.useStyle = 5;
			Item.knockBack = 4;
			Item.value = 20000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item12;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Ion Blaster");
			//Tooltip.SetDefault("");
		}
	}
}