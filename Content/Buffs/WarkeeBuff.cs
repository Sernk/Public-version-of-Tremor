using Terraria;
using Microsoft.Xna.Framework;
using TremorMod.Content.Projectiles;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class WarkeeBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Warkee");
			//Description.SetDefault("A warkee is following you");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;

            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Warkee>()] <= 0;

            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), new Vector2(player.position.X + player.width / 2, player.position.Y + player.height / 2), Vector2.Zero, ModContent.ProjectileType<Warkee>(), 0, 0f, player.whoAmI);
            }
        }
    }
}