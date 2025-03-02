using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;
using Microsoft.Xna.Framework;

namespace TremorMod.Content.Buffs
{
	public class LivingTombstoneBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Living Tombstone");
			//Description.SetDefault("Sadly, but it doesn't sing");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;

            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<LivingTombstonePro>()] <= 0;

            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(
                    player.GetSource_Buff(buffIndex), 
                    new Vector2(player.position.X + player.width / 2, player.position.Y + player.height / 2), 
                    Vector2.Zero, 
                    ModContent.ProjectileType<LivingTombstonePro>(), 
                    0, 
                    0f, 
                    player.whoAmI 
                );
            }
        }
    }
}