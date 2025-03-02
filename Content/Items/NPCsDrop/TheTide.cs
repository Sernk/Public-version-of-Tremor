using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.NPCsDrop
{
	public class TheTide : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 44;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 52;
			Item.height = 22;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 6;
			Item.value = 50000;

			Item.rare = 5;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 27;
			Item.shootSpeed = 26f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("The Tide");
			/* Tooltip.SetDefault("Shoots fast moving water bolts\n" +
			"Uses bullets as ammo"); */
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            type = 27; 
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
            return false; 
        }


        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-16, 0);
		}
	}
}
