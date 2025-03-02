using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.NPCsDrop
{
	public class SandShuriken : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 27;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 26;
			Item.noUseGraphic = true;
			Item.maxStack = 1;
			Item.height = 30;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.shoot = ModContent.ProjectileType<SandShurikenPro>();
			Item.shootSpeed = 27f;
			Item.useStyle = 1;
			Item.knockBack = 4;
			Item.value = 50000;
			Item.rare = 5;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sand Shuriken");
			Tooltip.SetDefault("Can be used infinitely");
		}*/
	}
}
