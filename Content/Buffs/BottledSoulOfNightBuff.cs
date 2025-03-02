using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class BottledSoulOfNightBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			// DisplayName.SetDefault("Bottled Soul of Night");
			// Description.SetDefault("8% increased melee speed");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetAttackSpeed(DamageClass.Melee) += 0.08f;
		}
	}
}
