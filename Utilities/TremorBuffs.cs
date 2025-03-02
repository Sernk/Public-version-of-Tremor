using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Utilities
{
	public class TremorBuffs : GlobalBuff
	{
		public override void Update(int type, Player player, ref int buffIndex)
		{
			if (player.FindBuffIndex(117) != -1)
			{
				player.GetModPlayer<MPlayer>().alchemicalDamage += 0.1f;
			}
			if (player.FindBuffIndex(115) != -1)
			{
				player.GetModPlayer<MPlayer>().alchemicalCrit += 10;
			}
		}
	}
}