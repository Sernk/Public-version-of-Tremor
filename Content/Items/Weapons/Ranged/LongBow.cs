using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class LongBow : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 14;
			Item.width = 16;
			Item.height = 32;
			Item.DamageType = DamageClass.Ranged;
			Item.useTime = 30;
			Item.shoot = 1;
			Item.shootSpeed = 8f;
			Item.useAnimation = 30;
			Item.useStyle = 5;
			Item.knockBack = 5;
			Item.value = 1040;
			Item.useAmmo = AmmoID.Arrow;
			Item.rare = 2;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Long Bow");
			//Tooltip.SetDefault("");
		}
	}
}