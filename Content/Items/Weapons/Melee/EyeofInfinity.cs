using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class EyeofInfinity : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 68;
			Item.DamageType = DamageClass.Melee;
			Item.width = 42;
			Item.height = 42;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.noMelee = true;
			Item.useStyle = 5;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(0, 1, 50, 0);
			Item.rare = 8;
			Item.UseSound = SoundID.Item23;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<projEyeofInfinity>();
			Item.shootSpeed = 15f;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Eye of Infinity");
			//Tooltip.SetDefault("");
		}
	}
}