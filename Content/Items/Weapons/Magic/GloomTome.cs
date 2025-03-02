using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Magic 
{
	public class GloomTome : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 23;
			Item.DamageType = DamageClass.Magic;
			Item.width = 28;
			Item.height = 30;
			Item.useTime = 14;
			Item.useAnimation = 14;
			Item.shoot = ModContent.ProjectileType<GloomSphere>();
			Item.shootSpeed = 16f;
			Item.mana = 12;
			Item.useStyle = 5;
			Item.knockBack = 3;
			Item.value = 5025;
			Item.rare = 3;
			Item.UseSound = SoundID.Item21;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Gloom Tome");
			//Tooltip.SetDefault("");
		}
	}
}