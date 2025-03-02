using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Biomes.Ice.Items
{
	public class IceCross : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 21;
			Item.width = 26;
			Item.height = 24;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 40;
			Item.useTime = 35;
			Item.shoot = ModContent.ProjectileType<Icoj>();
			Item.shootSpeed = 0f;
			Item.useAnimation = 35;
			Item.useStyle = 1;
			Item.value = 1000;
			Item.rare = 1;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Ice Cross");
			//Tooltip.SetDefault("Summons an giant stationary frozen boulder that damages enemies and explodes into icicles after some time");
		}
	}
}
