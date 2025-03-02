using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Throwing
{
	public class DragonBreath : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 46;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 18;
			Item.height = 18;
			Item.useTime = 14;
			Item.useAnimation = 14;
			Item.maxStack = 999;
			Item.shoot = ModContent.ProjectileType<DragonBreathPro>();
			Item.shootSpeed = 8f;
			Item.useStyle = 1;
			Item.knockBack = 3;
			Item.value = 155;
			Item.rare = 5;
			Item.consumable = true;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Dragon Breath");
			//Tooltip.SetDefault("");
		}
	}
}