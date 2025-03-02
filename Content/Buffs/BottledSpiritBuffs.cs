using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class BottledSpiritBuffs : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Bottled Spirit");
			//Description.SetDefault("Shoots two homing souls when using a flask");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}