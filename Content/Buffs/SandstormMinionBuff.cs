using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using TremorMod.Content.Projectiles.Minions;

namespace TremorMod.Content.Buffs
{
    public class SandstormMinionBuff : ModBuff
    {
        int MinionType = -1;
        int MinionID = -1;

        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            //DisplayName.SetDefault("Sandstorm Minion");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (MinionType == -1)
                MinionType = ModContent.ProjectileType<SandstormMinion>();

            if (MinionID == -1 || Main.projectile[MinionID].type != MinionType || !Main.projectile[MinionID].active || Main.projectile[MinionID].owner != player.whoAmI)
            {
                // Использование корректного источника
                IEntitySource source = player.GetSource_Buff(buffIndex);
                MinionID = Projectile.NewProjectile(
                    source,
                    player.Center,          // Позиция
                    Vector2.Zero,           // Скорость
                    MinionType,             // Тип снаряда
                    50,                     // Урон
                    1f,                     // Отброс
                    player.whoAmI           // Владелец
                );
            }
            else
            {
                Main.projectile[MinionID].timeLeft = 5;
            }
        }
    }
}
