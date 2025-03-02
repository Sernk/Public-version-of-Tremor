using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class ToxicRazorknife : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 29;
			Item.width = 16;
			Item.height = 32;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.useTime = 30;
			Item.shoot = ModContent.ProjectileType<ToxicRazorknifePro>();
			Item.shootSpeed = 12f;
			Item.useAnimation = 25;
			Item.useStyle = 5;
			Item.knockBack = 5;
			Item.value = 100000;
			Item.rare = 4;
			Item.UseSound = SoundID.Item10;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Toxic Razorknife");
			// Tooltip.SetDefault("");
		}

	}
}
