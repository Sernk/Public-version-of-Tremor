using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class ReinforcedBurstBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Reinforced Burst");
			//Description.SetDefault("Alchemical projectiles leave three death flames");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}