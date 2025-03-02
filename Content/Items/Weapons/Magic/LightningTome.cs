using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class LightningTome : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 15;
			//Item.melee = false;
			Item.DamageType = DamageClass.Magic;
			Item.width = 50;
			Item.height = 55;
			Item.useTime = 14;
			Item.mana = 7;
			Item.useAnimation = 14;
			Item.useStyle = 5;
			Item.shoot = ModContent.ProjectileType<LightningTomePro>();
			Item.shootSpeed = 12f;
			Item.knockBack = 4;
			Item.value = 50000;
			Item.rare = 3;
			Item.UseSound = SoundID.Item9;
			Item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Lightning Tome");
			//Tooltip.SetDefault("");
		}
	}
}