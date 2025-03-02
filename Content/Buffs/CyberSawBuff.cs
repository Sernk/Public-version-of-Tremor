using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles.Minions;
using TremorMod.Content;

namespace TremorMod.Content.Buffs
{
    public class CyberSawBuff : ModBuff
    {
        /*public override void SetDefaults()
		{
			//DisplayName.SetDefault("Cyber Saw");
			//Description.SetDefault("The cyber saw will fight for you");
			//Main.buffNoSave[Type] = true;
			//Main.buffNoTimeDisplay[Type] = true;
		}*/

        public override void Update(Player player, ref int buffIndex)
        {
            // Получаем экземпляр modPlayer для этого игрока
            //TremorPlayer modPlayer = player.GetModPlayer<TremorPlayer>();

            // Проверка наличия миньона
            /*if (player.ownedProjectileCounts[ModContent.ProjectileType<CyberStaffPro>()] > 0)
            {
                modPlayer.cyberMinion = true; // Устанавливаем флаг, что миньон активен
            }*/

            // Если миньон не активен, удаляем бафф
            /*if (!modPlayer.cyberMinion)
            {
                player.DelBuff(buffIndex);
                buffIndex = -1;  // Устанавливаем buffIndex в -1, чтобы избежать IndexOutOfRangeException
            }*/
            
            {
                // Продолжаем действие баффа
                player.buffTime[buffIndex] = 18000;
            }
        }

    }
}