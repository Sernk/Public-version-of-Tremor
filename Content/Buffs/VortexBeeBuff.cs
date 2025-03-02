using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Buffs
{
	public class VortexBeeBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Vortex Bee");
			// Description.SetDefault("A vortex bee is following you");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;

            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<VortexBee>()] <= 0;

            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), new Vector2(player.position.X + player.width / 2, player.position.Y + player.height / 2), Vector2.Zero, ModContent.ProjectileType<VortexBee>(), 0, 0f, player.whoAmI);
            }
        }
    }
}