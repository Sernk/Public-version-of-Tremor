using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Throwing
{
	public class Bonecrusher : ModItem
	{
		public override void SetDefaults()
		{
			Item.autoReuse = true;
			Item.useStyle = 1;

			Item.shootSpeed = 8f;
			Item.shoot = ModContent.ProjectileType<BonecrusherPro>();
			Item.damage = 24;
			Item.width = 18;
			Item.height = 20;
			Item.UseSound = SoundID.Item1;
			Item.useAnimation = 14;
			Item.useTime = 17;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.value = 6000;
			Item.knockBack = 4f;
			Item.rare = 3;
			Item.DamageType = DamageClass.Throwing;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Bonecrusher");
			// Tooltip.SetDefault("");
		}

		public override bool CanUseItem(Player player)
		{
			for (int i = 0; i < 1000; ++i)
			{
				if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == Item.shoot)
				{
					return false;
				}
			}
			return true;
		}
	}
}
