using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class BlueSakuraBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Blue Wind");
			//Description.SetDefault("The blue wind will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}		
	}
}