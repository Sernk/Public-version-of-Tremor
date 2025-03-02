using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class ChainedRocket : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.rare = 11;
			Item.noMelee = true;
			Item.useStyle = 5;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.value = 2100000;
			Item.knockBack = 7.5F;
			Item.damage = 262;
			Item.autoReuse = true;
			Item.scale = 1.1F;
			Item.noUseGraphic = true;
			Item.shoot = ModContent.ProjectileType<ChainedRocketPro>();
			Item.shootSpeed = 22.9F;
			Item.UseSound = SoundID.Item1;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.channel = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Chained Rocket");
			// Tooltip.SetDefault("");
		}

	}
}
