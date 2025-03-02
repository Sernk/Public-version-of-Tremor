using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.BossLoot.TheDarkEmperor
{
	public class SBCCannonballAmmo : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 340;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 22;
			Item.height = 22;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 1.5f;
			Item.value = 1000;
			Item.rare = 11;
			Item.shoot = ModContent.ProjectileType<SuperBigCannonPro>();
			Item.ammo = Item.type;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("SBC Cannonball");
			//Tooltip.SetDefault("");
		}
	}
}