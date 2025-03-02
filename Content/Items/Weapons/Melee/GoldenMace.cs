using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class GoldenMace : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 34;
			Item.DamageType = DamageClass.Melee;
            Item.width = 50;
			Item.height = 52;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = 1;
			Item.shoot = ModContent.ProjectileType<GoldenMacePro>();
			Item.shootSpeed = 10f;
			Item.knockBack = 4;
			Item.value = 80000;
			Item.rare = 4;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Golden Mace");
			//Tooltip.SetDefault("");
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 246);
		}

	}
}
