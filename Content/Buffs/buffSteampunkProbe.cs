using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using TremorMod.Content.Projectiles.Minions;

namespace TremorMod.Content.Buffs
{
    public class buffSteampunkProbe : ModBuff
    {
        int Probe = -1;

        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            //DisplayName.SetDefault("SteampunkProbe");
            //Description.SetDefault("This probe protects you.");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            // Проверяем, активен ли бафф
            if (player.buffTime[buffIndex] >= 2)
            {
                // Если снаряд не был создан
                if (Probe == -1 || !Main.projectile[Probe].active || Main.projectile[Probe].type != ModContent.ProjectileType<projSteampunkProbe>())
                {
                    // Используем правильный источник для снаряда
                    IEntitySource entitySource = player.GetSource_Buff(buffIndex);

                    // Создаем снаряд с корректными типами данных
                    Probe = Projectile.NewProjectile(entitySource, player.Center, Vector2.Zero, ModContent.ProjectileType<projSteampunkProbe>(), 0, 0, player.whoAmI);
                }

                // Обновляем время жизни снаряда
                if (Main.projectile[Probe].active)
                {
                    Main.projectile[Probe].timeLeft = 6; // Устанавливаем время жизни снаряда
                }
            }
            else
            {
                // Если бафф не активен, деактивируем снаряд
                if (Probe != -1 && Main.projectile[Probe].active)
                {
                    Main.projectile[Probe].active = false;
                }
            }
        }
    }
}
