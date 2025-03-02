using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.BossLoot.TheDarkEmperor
{
	public class NastyJavelin : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 162;
			Item.width = 14;
			Item.DamageType = DamageClass.Throwing;
			Item.height = 84;
			Item.noUseGraphic = true;
			Item.consumable = true;
			Item.maxStack = 999;
			Item.useTime = 22;
			Item.shoot = ModContent.ProjectileType<NastyJavelinPro>();
			Item.shootSpeed = 20f;
			Item.useAnimation = 22;
			Item.useStyle = 1;
			Item.knockBack = 4;
			Item.value = 10000;
			Item.rare = 11;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Nasty Javelin");
			//Tooltip.SetDefault("");
		}
	}
}