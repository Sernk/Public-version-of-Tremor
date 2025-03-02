using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class SpearofJustice : ModItem
	{
		public override void SetDefaults()
		{

			Item.value = 1000000;
			Item.useStyle = 1;
			Item.useAnimation = 20;
			Item.useTime = 20;

			Item.autoReuse = true;
			Item.rare = 11;
			Item.width = 42;
			Item.height = 42;
			Item.UseSound = SoundID.Item8;
			Item.damage = 228;
			Item.knockBack = 4;
			Item.mana = 8;
			Item.shoot = ModContent.ProjectileType<SpearofJusticePro>();
			Item.shootSpeed = 14f;
			Item.noMelee = true; //So that the swing itself doesn't do damage; this weapon is projectile-only
			Item.noUseGraphic = true; //No swing animation
			Item.DamageType = DamageClass.Magic;
			Item.crit = 7;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Spear of Justice");
			// Tooltip.SetDefault("'NGAAAAAHHHHHHHHHHHHHHHHH!'");
		}

	}
}
