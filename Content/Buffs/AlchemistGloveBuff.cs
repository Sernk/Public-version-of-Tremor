using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class AlchemistGloveBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Master Alchemist Glove");
			// Description.SetDefault("Alchemic weapons throw two flasks");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}