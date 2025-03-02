using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class TomeRechargeBuff1 : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.debuff[Type] = true;
			// DisplayName.SetDefault("Soul Recharging");
			// Description.SetDefault("Wait untill Book of Revelations recharge souls");
		}

	}
}
