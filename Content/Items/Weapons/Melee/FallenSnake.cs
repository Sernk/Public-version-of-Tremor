using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class FallenSnake : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.ValkyrieYoyo);
			Item.damage = 180;
			Item.width = 30;
			Item.height = 26;
			Item.shootSpeed = 25f;
			Item.shoot = ModContent.ProjectileType<FallenSnakePro>();
			Item.knockBack = 5;
			Item.value = 1000000;
			Item.rare = 11;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("The Fallen Snake");
			//Tooltip.SetDefault("Killed enemies drop more money");
		}
	}
}