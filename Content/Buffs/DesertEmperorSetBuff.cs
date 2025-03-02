using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class DesertEmperorSetBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Desert Wasp");
			//Description.SetDefault("Releases a wasp to attack enemies when a flask explodes");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}