using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class CrabBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Little Crab");
			//Description.SetDefault("A little crab will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}