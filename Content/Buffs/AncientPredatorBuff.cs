using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using TremorMod.Content.Projectiles.Minions;

namespace TremorMod.Content.Buffs
{
	public class AncientPredatorBuff : ModBuff
	{
		int MinionType = -1;
		int MinionID = -1;

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("The Ancient Predator");
			//Description.SetDefault("The ancient predator defends you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

        public override void Update(Player player, ref int buffIndex)
        {
            if (MinionType == -1)
                MinionType = ModContent.ProjectileType<AncientPredator>();

            if (MinionID == -1 || Main.projectile[MinionID].type != MinionType || !Main.projectile[MinionID].active || Main.projectile[MinionID].owner != player.whoAmI)
            {
                IEntitySource source = player.GetSource_Buff(buffIndex); // Источник для вызова
                Vector2 position = player.Center; // Позиция спавна
                Vector2 velocity = Vector2.Zero;  // Нулевая скорость

                MinionID = Projectile.NewProjectile(source, position, velocity, MinionType, 300, 3f, player.whoAmI);
            }
            else
            {
                Main.projectile[MinionID].timeLeft = 5;
            }
        }
    }
}