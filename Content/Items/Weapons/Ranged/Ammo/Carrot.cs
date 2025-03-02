using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Ranged.Ammo
{
	public class Carrot : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 15;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 22;
			Item.height = 22;
			Item.maxStack = 999;

			Item.consumable = true;
			Item.knockBack = 1.5f;
			Item.rare = 0;
			Item.shoot = ModContent.ProjectileType<CarrotPro>();
			Item.ammo = Item.type;
			Item.value = 15;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Carrot");
			//Tooltip.SetDefault("");
		}
	}
}