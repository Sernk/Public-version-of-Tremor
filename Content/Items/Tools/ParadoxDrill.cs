using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Tools
{

	public class ParadoxDrill : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 9;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 40;
			Item.height = 22;
			Item.useTime = 4;
			Item.useAnimation = 12;
			Item.channel = true;

			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.useStyle = 5;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(0, 10, 0, 0);
			Item.rare = 11;
			Item.UseSound = SoundID.Item23;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<ParadoxDrillPro>();
			Item.shootSpeed = 20f;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Paradox Drill");
			/* Tooltip.SetDefault("Press LMB to use drill\n" +
"Press RMB to use axe and hammer"); */
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				Item.useStyle = 5;
				Item.useTime = 15;
				Item.useAnimation = 15;
				Item.axe = 40;
				Item.hammer = 200;
				Item.pick = 0;
				Item.shoot = ModContent.ProjectileType<ParadoxDrillPro>();
			}
			else
			{
				Item.useStyle = 5;
				Item.useTime = 4;
				Item.useAnimation = 12;
				Item.axe = 0;
				Item.hammer = 0;
				Item.pick = 265;
				Item.shoot = ModContent.ProjectileType<ParadoxDrillPro>();
			}
			return base.CanUseItem(player);
		}
	}
}
