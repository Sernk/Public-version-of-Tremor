using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class AxeofExecutioner : ModItem
	{
		public override void SetDefaults()
		{
			Item.autoReuse = true;
			Item.useStyle = 1;
			Item.shootSpeed = 8f;
			Item.shoot = ModContent.ProjectileType<AxeofExecutionerPro>();
			Item.damage = 175;
			Item.width = 18;
			Item.height = 20;
			Item.UseSound = SoundID.Item1;
			Item.useAnimation = 14;
			Item.useTime = 17;
			Item.noUseGraphic = true;
			Item.value = 500000;
			Item.knockBack = 5f;
            Item.DamageType = DamageClass.Melee;
            Item.rare = 10;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Axe of Executioner");
			Tooltip.SetDefault("");
		}*/
	}
}
