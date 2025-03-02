using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Buffs
{
	public class NebulaJellyfishBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Nebula Jellyfish");
			//Description.SetDefault("A nebula jellyfish is following you");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;

            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<NebulaJellyfish>()] <= 0;

            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile( player.GetSource_Buff(buffIndex),new Vector2(player.position.X + player.width / 2, player.position.Y + player.height / 2),  Vector2.Zero,ModContent.ProjectileType<NebulaJellyfish>(),0,  0f, player.whoAmI);                  
            }
        }
    }
}