using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class ZephyrhornBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Zephyrhorn");
			// Description.SetDefault("Increased minion size");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetDamage(DamageClass.Summon) += 0.1f;
		}
	}
}
