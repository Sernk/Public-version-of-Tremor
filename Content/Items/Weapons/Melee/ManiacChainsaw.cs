using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Melee
{

	public class ManiacChainsaw : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 202;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 140;
			Item.height = 34;
			Item.useTime = 8;
			Item.useAnimation = 25;
			Item.channel = true;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.axe = 35;
			Item.tileBoost += 5;
			Item.useStyle = 5;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(0, 1, 50, 0);
			Item.rare = 10;
			Item.UseSound = SoundID.Item23;
			Item.autoReuse = true;

			Item.shoot = ModContent.ProjectileType<ManiacChainsawPro>();
			Item.shootSpeed = 0.4f;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Maniacal Chainsaw");
			// Tooltip.SetDefault("'A weapon of a true man killer'");
		}

	}
}
