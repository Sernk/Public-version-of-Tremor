using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
    public class ManaBoosterBuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            if (!ModContent.GetInstance<TremorConfig>().AllowManaBuffsTogether && player.HasBuff(ModContent.BuffType<ExtendedManaBooster>()))
            {
                player.DelBuff(buffIndex);
                buffIndex--;
                return;
            }

            if (player.buffTime[buffIndex] == 0)
            {
                player.statMana += 150;
                player.ManaEffect(150);
                player.AddBuff(ModContent.BuffType<ManaBoosterBuff>(), 3600);
            }
        }
    }
}
