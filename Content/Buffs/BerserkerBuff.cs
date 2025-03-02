using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles.Minions;

namespace TremorMod.Content.Buffs
{
    public class BerserkerBuff : ModBuff
    {
        int MinionType = -1;
        int MinionID = -1;

        const int Damage = 30;
        const float KB = 1;

        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            //DisplayName.SetDefault("Berserker");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (MinionType == -1)
                MinionType = ModContent.ProjectileType<BerserkerPro>();

            if (MinionID == -1 ||
                Main.projectile[MinionID].type != MinionType ||
                !Main.projectile[MinionID].active ||
                Main.projectile[MinionID].owner != player.whoAmI)
            {
                MinionID = Projectile.NewProjectile(
                    player.GetSource_Buff(buffIndex),
                    player.Center.X,
                    player.Center.Y,
                    0,
                    0,
                    MinionType,
                    (int)(Damage * player.GetDamage(DamageClass.Melee).Additive),
                    KB,
                    player.whoAmI);
            }
            else
            {
                Main.projectile[MinionID].timeLeft = 6;
            }
        }
    }
}