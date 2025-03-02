using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Throwing
{
	public class ThrowingCog : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 49;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 30;
			Item.noUseGraphic = true;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.height = 30;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.shoot = ModContent.ProjectileType<ThrowingCogPro>();
			Item.shootSpeed = 10f;
			Item.useStyle = 1;
			Item.knockBack = 4;
			Item.value = 7;
			Item.rare = 5;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Throwing Cog");
			// Tooltip.SetDefault("");
		}

	}
}
