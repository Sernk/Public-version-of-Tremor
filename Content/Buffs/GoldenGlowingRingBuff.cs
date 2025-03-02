using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles.Minions;

namespace TremorMod.Content.Buffs
{
    public class GoldenGlowingRingBuff : ModBuff
    {
        int MinionType = -1;
        int MinionID = -1;

        int MinionType1 = -1;
        int MinionID1 = -1;

        const int Damage = 26;
        const float KB = 1;

        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            //DisplayName.SetDefault("Fungus Blades");
            //Description.SetDefault("Summons two blades to protect you");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            // Получаем типы и ID снарядов
            if (MinionType == -1)
                MinionType = ModContent.ProjectileType<FungusBlueSword>();
            if (MinionType1 == -1)
                MinionType1 = ModContent.ProjectileType<FungusYellowSword>();

            // Рассчитываем урон, учитывая модификаторы ближнего боя игрока
            int meleeDamage = (int)(Damage * player.GetTotalDamage(DamageClass.Melee).Multiplicative);

            // Обновляем или создаем первый меч
            if (MinionID == -1 || Main.projectile[MinionID].type != MinionType || !Main.projectile[MinionID].active || Main.projectile[MinionID].owner != player.whoAmI)
                MinionID = Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.Center.X, player.Center.Y, 0, 0, MinionType, meleeDamage, KB, player.whoAmI);
            else
                Main.projectile[MinionID].timeLeft = 6;

            // Обновляем или создаем второй меч
            if (MinionID1 == -1 || Main.projectile[MinionID1].type != MinionType1 || !Main.projectile[MinionID1].active || Main.projectile[MinionID1].owner != player.whoAmI)
                MinionID1 = Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.Center.X, player.Center.Y, 0, 0, MinionType1, meleeDamage, KB, player.whoAmI);
            else
                Main.projectile[MinionID1].timeLeft = 6;
        }
    }
}
