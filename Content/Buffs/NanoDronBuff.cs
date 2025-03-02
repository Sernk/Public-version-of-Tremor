using System;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles.Minions;

namespace TremorMod.Content.Buffs
{
    public class NanoDronBuff : ModBuff
    {
        int MinionType = -1;
        int MinionID = -1;

        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            //DisplayName.SetDefault("Nano Dron");
            //Description.SetDefault("Summons a dron that destroys your enemies");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (MinionType == -1)
                MinionType = ModContent.ProjectileType<NanoDronPro>();

            // Проверяем наличие активного миньона
            if (MinionID == -1 ||
                !Main.projectile[MinionID].active ||
                Main.projectile[MinionID].type != MinionType ||
                Main.projectile[MinionID].owner != player.whoAmI)
            {
                // Создаем источник действия корректно
                IEntitySource source = player.GetSource_Buff(buffIndex);

                // Вызываем нового миньона
                MinionID = Projectile.NewProjectile(
                    source,             // Источник действия
                    player.Center,       // Позиция
                    Vector2.Zero,        // Скорость
                    MinionType,          // Тип миньона
                    50,                  // Урон
                    1f,                  // Отброс
                    player.whoAmI        // Владелец
                );
            }
            else
            {
                // Обновляем время жизни миньона
                Main.projectile[MinionID].timeLeft = 5;
            }
        }
    }
}
