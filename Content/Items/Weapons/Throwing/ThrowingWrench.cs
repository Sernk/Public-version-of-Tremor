using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Throwing
{
	public class ThrowingWrench : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 25;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 28;
			Item.noUseGraphic = true;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.height = 30;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.shoot = 582;
			Item.shootSpeed = 14f;
			Item.useStyle = 1;
			Item.knockBack = 4;
			Item.value = 60;
			Item.rare = 4;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Throwing Wrench");
			// Tooltip.SetDefault("");
		}

	}
}