using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class TheCadenceBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("The Cadence");
			//Description.SetDefault("Flasks attack your enemies with souls");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}