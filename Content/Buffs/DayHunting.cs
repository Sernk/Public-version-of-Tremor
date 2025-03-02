using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class DayHunting : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Day Hunting");
			// Description.SetDefault("Increases all stats during daytime");
		}

		public override void Update(Player player, ref int buffIndex)
		{

			if (Main.dayTime)
			{
				player.GetDamage(DamageClass.Melee) += 0.15f;
				player.GetCritChance(DamageClass.Melee) += 12;
				player.GetDamage(DamageClass.Magic) += 0.15f;
				player.GetCritChance(DamageClass.Magic) += 12;
				player.GetDamage(DamageClass.Ranged) += 0.15f;
				player.GetCritChance(DamageClass.Ranged) += 12;
				player.GetDamage(DamageClass.Summon) += 0.15f;
				player.GetDamage(DamageClass.Throwing) += 0.15f;
				player.moveSpeed += 0.25f;
			}
		}
	}
}
