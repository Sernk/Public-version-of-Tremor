using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Ranged
{
	public class ChainBow : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 300;
			Item.width = 16;
			Item.height = 32;
			Item.DamageType = DamageClass.Ranged;
			Item.useTime = 20;
			Item.shoot = 1;
			Item.shootSpeed = 60f;
			Item.useAnimation = 20;
			Item.useStyle = 5;
			Item.knockBack = 5;
			Item.value = 1250000;
			Item.useAmmo = AmmoID.Arrow;
			Item.rare = 11;
			Item.crit = 7;
			Item.UseSound = SoundID.Item114;
			Item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Chain Bow");
			// Tooltip.SetDefault("Shoots cosmic rays!");
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity, ProjectileID.MagnetSphereBolt, damage, knockback, player.whoAmI);
            return false; 
        }
    }
}
