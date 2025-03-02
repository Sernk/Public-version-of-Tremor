using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Throwing
{
	public class BoomSpear : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 18;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 18;
			Item.noUseGraphic = true;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.height = 38;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.shoot = 246;
			Item.shootSpeed = 8f;
			Item.useStyle = 1;
			Item.knockBack = 4;
			Item.value = 80;
			Item.rare = 2;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Boom Javelin");
			//Tooltip.SetDefault("");
		}
	}
}