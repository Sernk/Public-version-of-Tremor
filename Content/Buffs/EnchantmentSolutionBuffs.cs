using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class EnchantmentSolutionBuffs : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Enchantment Solution");
			//Description.SetDefault("25% chance not to consume flask");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}