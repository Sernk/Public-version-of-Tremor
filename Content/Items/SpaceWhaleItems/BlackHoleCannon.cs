using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.SpaceWhaleItems
{
	public class BlackHoleCannon : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 250;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 15;
			Item.width = 68;
			Item.height = 28;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.shoot = 617;
			Item.shootSpeed = 15f;
			Item.useStyle = 5;
			Item.knockBack = 4;
			Item.value = 20000;
			Item.rare = 11;
			Item.UseSound = SoundID.Item12;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Blackhole Cannon");
			//Tooltip.SetDefault("Shoots deadly black holes");
		}

	}
}
