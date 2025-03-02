using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class Pumpspell : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 26;
			Item.DamageType = DamageClass.Magic;
			Item.width = 28;
			Item.height = 30;
			Item.useTime = 14;
			Item.useAnimation = 14;
			Item.shoot = ModContent.ProjectileType<PumpkinPro>();
			Item.shootSpeed = 10f;
			Item.noUseGraphic = true;
			Item.mana = 16;
			Item.useStyle = 5;
			Item.knockBack = 3;
			Item.value = 66666;
			Item.rare = 4;
			Item.UseSound = SoundID.Item21;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Pumpspell");
			//Tooltip.SetDefault("");
		}
	}
}