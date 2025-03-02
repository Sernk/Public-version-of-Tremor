using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class PrimeBlade : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 52;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.shoot = 503;
			Item.shootSpeed = 12f;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 60000;
			Item.rare = 5;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Prime Blade");
			//Tooltip.SetDefault("'Mechanical rage!'");
		}
	}
}