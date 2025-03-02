using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class BirbStaffBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Birb");
			//Description.SetDefault("A birb will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}