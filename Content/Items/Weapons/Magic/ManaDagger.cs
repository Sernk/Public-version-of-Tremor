using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class ManaDagger : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 14;
			Item.height = 28;
			Item.rare = 7;
			Item.damage = 30;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 12;
			Item.useTime = 8;
			Item.useAnimation = 8;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 1;
			Item.value = 270000;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = false;
			Item.shoot = ModContent.ProjectileType<projManaDagger>();
			Item.shootSpeed = 15f;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Mana Dagger");
			//Tooltip.SetDefault("A magical returning dagger\n" +
			//"Gives mana after hitting an enemy and returning");
		}
	}
}