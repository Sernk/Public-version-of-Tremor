using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class MeteorBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Metor Head");
			//Description.SetDefault("The meteor head will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}		
	}
}