using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class CreeperBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Creeper");
			//Description.SetDefault("The creeper will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}