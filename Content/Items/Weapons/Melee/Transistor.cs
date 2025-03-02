using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Weapons.Melee
{
	public class Transistor : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 133;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 66;
			Item.height = 66;

			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = 1;
			Item.knockBack = 3;
			Item.value = 13500;
			Item.rare = 8;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<BrainiacWavePro>();
			Item.shootSpeed = 9f;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Transistor");
			/* Tooltip.SetDefault("'Crash() everyone!'\n" +
"Sends energy waves in different directions on swing"); */
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 speed = velocity;
            speed = speed.RotatedByRandom(MathHelper.ToRadians(60));
            velocity = speed;
            return true;
        }
	}
}
