using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class BrassChipBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Brass Chip");
			//Description.SetDefault("Shoots rockets from the sky when a flask is destroyed");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}