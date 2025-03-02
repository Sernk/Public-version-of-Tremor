using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles.Minions;
using Microsoft.Xna.Framework;

namespace TremorMod.Content.Buffs
{
	public class NorthwindBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("North wind");
			//Description.SetDefault("The frost ghost will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;

            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<NorthWindMinion>()] <= 0;

            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), new Vector2(player.position.X + player.width / 2, player.position.Y + player.height / 2), Vector2.Zero, ModContent.ProjectileType<NorthWindMinion>(), 0, 0f, player.whoAmI);
            }
        }
    }
}