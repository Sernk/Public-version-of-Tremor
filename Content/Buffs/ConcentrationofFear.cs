using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class ConcentrationofFear : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Concentration of Fear");
			//Description.SetDefault("Increased all damage");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetDamage(DamageClass.Generic) += 0.25f;
			player.GetCritChance(DamageClass.Generic) += 5;
			player.GetAttackSpeed(DamageClass.Melee) += 0.15f;
			player.GetKnockback(DamageClass.Summon) += 0.5f;
            player.statDefense += 15;
			player.moveSpeed += 0.15f;
		}
	}
}