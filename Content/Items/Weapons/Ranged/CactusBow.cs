using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class CactusBow : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 14;
			Item.width = 16;
			Item.height = 32;
			Item.DamageType = DamageClass.Ranged;
			Item.useTime = 40;
			Item.shoot = 1;
			Item.shootSpeed = 10f;
			Item.useAnimation = 30;
			Item.useStyle = 5;
			Item.knockBack = 5;
			Item.value = 2040;
			Item.useAmmo = AmmoID.Arrow;
			Item.rare = 2;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Cactus Bow");
			//Tooltip.SetDefault("");
		}
	}
}