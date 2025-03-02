using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class LongFuseBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Long fuse");
			//Description.SetDefault("Alchemic weapon throws further");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}