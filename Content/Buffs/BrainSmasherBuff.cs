using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Buffs
{
	public class BrainSmasherBuff : ModBuff
	{
		int MinionType = -1;
		int MinionID = -1;

		const int Damage = 90;
		const float KB = 1;

		public override void SetStaticDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			//DisplayName.SetDefault("Brain Smasher");
		}

        public override void Update(Player player, ref int buffIndex)
        {
            if (MinionType == -1)
                MinionType = ModContent.ProjectileType<BrainSmasherPro>();
            if (MinionID == -1 || Main.projectile[MinionID].type != MinionType || !Main.projectile[MinionID].active || Main.projectile[MinionID].owner != player.whoAmI)
                MinionID = Projectile.NewProjectile(
                    player.GetSource_Buff(buffIndex),
                    player.Center,
                    Vector2.Zero,
                    MinionType,
                    (int)(Damage * player.GetDamage(DamageClass.Melee).ApplyTo(1f)),
                    KB,
                    player.whoAmI
                );
            else
                Main.projectile[MinionID].timeLeft = 6;
        }
    }
}