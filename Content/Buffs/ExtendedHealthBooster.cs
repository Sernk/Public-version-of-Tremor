using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
    public class ExtendedHealthBooster : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            if (!ModContent.GetInstance<TremorConfig>().AllowHealthBuffsTogether && player.HasBuff(ModContent.BuffType<HealthBoosterBuff>()))
            {
                player.DelBuff(buffIndex);
                buffIndex--;
                return;
            }

            if (player.buffTime[buffIndex] == 0)
            {
                player.statLife += 150;
                player.HealEffect(150);
                player.AddBuff(ModContent.BuffType<ExtendedHealthBooster>(), 2700);
            }
        }
    }
}
