using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class ElectricSpear : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 25;
			Item.width = 70;
			Item.height = 70;
			Item.noUseGraphic = true;
			Item.DamageType = DamageClass.Melee;
			Item.useTime = 25;
			Item.shoot = ModContent.ProjectileType<ElectricSpearPro>();
			Item.shootSpeed = 5f;
			Item.useAnimation = 30;
			Item.useStyle = 5;
			Item.knockBack = 4;
			Item.value = 12500;
			Item.rare = 3;
			Item.UseSound = SoundID.Item93;
			Item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Electric Spear");
			//Tooltip.SetDefault("'Traitor!'");
		}
	}
}