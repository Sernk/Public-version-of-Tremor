using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Buffs
{
	public class petGenie : ModBuff
	{
		public int MyDzhin = -1;

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Genie");
			//Description.SetDefault("A Genie follows you and shows location of enemies");
			Main.buffNoTimeDisplay[Type] = true;
		}

        public override void Update(Player player, ref int buffIndex)
        {
            foreach (NPC npc in Main.npc)
            {
                if (npc.friendly || npc.lifeMax <= 5 || !npc.active || npc.Distance(player.position) > 750)
                    continue;
                Lighting.AddLight(npc.Center, new Vector3(0, 0, 1));
            }

            if (MyDzhin == -1)
            {
                IEntitySource source = player.GetSource_Buff(buffIndex);
                MyDzhin = Projectile.NewProjectile(source, player.Center, Vector2.Zero,
                    ModContent.ProjectileType<projGenie>(), 0, 0, player.whoAmI);
            }

            if (!Main.projectile[MyDzhin].active || Main.projectile[MyDzhin].type != ModContent.ProjectileType<projGenie>())
            {
                IEntitySource source = player.GetSource_Buff(buffIndex);
                MyDzhin = Projectile.NewProjectile(source, player.Center, Vector2.Zero,
                    ModContent.ProjectileType<projGenie>(), 0, 0, player.whoAmI);
            }

            Main.projectile[MyDzhin].timeLeft = 2;
            player.buffTime[buffIndex] = 2;
        }
    }
}