using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
    public class ExtendedManaBooster : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            if (!ModContent.GetInstance<TremorConfig>().AllowManaBuffsTogether && player.HasBuff(ModContent.BuffType<ManaBoosterBuff>()))
            {
                player.DelBuff(buffIndex);
                buffIndex--;
                return;
            }

            if (player.buffTime[buffIndex] == 0)
            {
                player.statMana += 200;
                player.ManaEffect(200);
                player.AddBuff(ModContent.BuffType<ExtendedManaBooster>(), 2700);
            }
        }
    }
}