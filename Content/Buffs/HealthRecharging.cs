using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class HealthRecharging : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.debuff[Type] = true;
			//DisplayName.SetDefault("Health Recharging");
			//Description.SetDefault("Wait before you can use the hourglass again");
		}
	}
}