using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class BottledSoulOfMightBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			// DisplayName.SetDefault("Bottled Soul of Might");
			// Description.SetDefault("5% increased damage");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetDamage(DamageClass.Melee) += 0.05f;
			player.GetDamage(DamageClass.Ranged) += 0.05f;
			player.GetDamage(DamageClass.Throwing) += 0.05f;
			player.GetDamage(DamageClass.Summon) += 0.05f;
			player.GetDamage(DamageClass.Magic) += 0.05f;
		}
	}
}
