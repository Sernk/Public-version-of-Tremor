using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Weapons.Magic
{
	public class LightningStaff : ModItem
	{
		public override void SetDefaults()
		{
			Item.mana = 22;
			Item.UseSound = SoundID.Item82;
			Item.useStyle = 5;
			Item.damage = 180;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.width = 36;
			Item.height = 40;
			Item.shoot = 580;
			Item.shootSpeed = 13f;
			Item.knockBack = 4.4f;
			Item.staff[Item.type] = true;
			Item.DamageType = DamageClass.Magic;
			Item.autoReuse = true;
			Item.value = 100000;
			Item.rare = 11;
			//Item.noMelee = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Lightning Staff");
			//Tooltip.SetDefault("Sends out huge lightnings");
		}

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            ProjectileID.Sets.IsAWhip[type] = false; 
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 vector82 = -Main.player[Main.myPlayer].Center + Main.MouseWorld;
            float ai = Main.rand.Next(100);
            Vector2 vector83 = Vector2.Normalize(vector82) * Item.shootSpeed;
            Projectile.NewProjectile(source, player.Center.X, player.Center.Y, vector83.X, vector83.Y, type, damage, knockback, player.whoAmI, vector82.ToRotation(), ai);
            return false;
        }
    }
}