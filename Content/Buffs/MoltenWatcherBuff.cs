using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Buffs
{
	public class MoltenWatcherBuff : ModBuff
	{
		int MinionType = -1;
		int MinionID = -1;

		public override void SetStaticDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			//DisplayName.SetDefault("Molten Watcher");
			//Description.SetDefault("Summons an eye to burn your foes");
		}

        public override void Update(Player player, ref int buffIndex)
        {
            if (MinionType == -1)
                MinionType = ModContent.ProjectileType<MoltenWatcher>();

            if (MinionID == -1 || !Main.projectile[MinionID].active || Main.projectile[MinionID].owner != player.whoAmI || Main.projectile[MinionID].type != MinionType)
            {
                MinionID = Projectile.NewProjectile(
                    player.GetSource_Buff(buffIndex), 
                    player.Center, 
                    Vector2.Zero, 
                    MinionType, 
                    0, 
                    0f, 
                    player.whoAmI 
                );
            }
            else
            {
                Main.projectile[MinionID].timeLeft = 5;
            }
        }

    }
}
