using Terraria;
using Terraria.ModLoader;
using TremorMod;
using TremorMod.Utilities;

namespace TremorMod.Content.Buffs
{
    public class FragileCondition : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Fragile Condition");
            // Description.SetDefault("You deal three times more damage, but your defense is reduced to zero.");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            // Увеличение урона в 3 раза
            player.GetDamage(DamageClass.Magic) *= 3f;
            player.GetDamage(DamageClass.Summon) *= 3f;
            player.GetDamage(DamageClass.Melee) *= 3f;
            player.GetDamage(DamageClass.Ranged) *= 3f;
            player.GetDamage(DamageClass.Throwing) *= 3f;
            MPlayer.GetModPlayer(player).alchemicalDamage *= 3f;
            MPlayer.GetModPlayer(player).fragileCondition = true; // Исправлено
        }
    }
}
