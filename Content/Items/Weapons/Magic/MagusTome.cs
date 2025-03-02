using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class MagusTome : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 25;
			//Item.melee = false;
			Item.DamageType = DamageClass.Magic;
			Item.width = 50;
			Item.height = 55;
			Item.useTime = 25;
			Item.mana = 9;
			Item.useAnimation = 25;
			Item.useStyle = 5;
			Item.shoot = ModContent.ProjectileType<MagusBallF>();
			Item.shootSpeed = 12f;
			Item.knockBack = 4;
			Item.value = 32000;
			Item.rare = 4;
			Item.UseSound = SoundID.Item9;
			Item.autoReuse = true;

		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Magus Tome");
			//Tooltip.SetDefault("Shoots out a bolt that pierces enemies and explodes on contant with blocks");
		}
	}
}