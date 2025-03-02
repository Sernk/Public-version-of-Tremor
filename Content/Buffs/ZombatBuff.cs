using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TremorMod.Content.Projectiles.Minions;
using TremorMod;

namespace TremorMod.Content.Buffs
{
	public class ZombatBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Zombat");
			// Description.SetDefault("The zombat will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

        public override void Update(Player player, ref int buffIndex)
        {
            TremorPlayer modPlayer = player.GetModPlayer<TremorPlayer>();
            if (player.ownedProjectileCounts[ModContent.ProjectileType<ZombatStaffPro>()] > 0)
            {
                modPlayer.whiteSakura = true;
            }
            if (!modPlayer.whiteSakura)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
            {
                player.buffTime[buffIndex] = 18000;
            }
        }
    }
}