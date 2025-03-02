using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Items.Accessories
{
	public class AncientSoul : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 36;
			Item.rare = 9;
			Item.accessory = true;
			Item.value = 30000;
			Item.expert = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Ancient Soul");
			//Tooltip.SetDefault("Creates a shield of souls to protect you\n" +
			//"More souls appear after some time and each soul disappear after second hit of enemy");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 3));
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (Main.rand.Next(250) == 0)
            {
                if (player.ownedProjectileCounts[ModContent.ProjectileType<AncientShield>()] <= 4)
                {
                    IEntitySource source = player.GetSource_Accessory(this.Item); 
                    Projectile.NewProjectile(source, player.position, Vector2.Zero, ModContent.ProjectileType<AncientShield>(), 20, 0, player.whoAmI);
                }
            }
        }
    }
}
