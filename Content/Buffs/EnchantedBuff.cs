using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class EnchantedBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Enchanted");
			//Description.SetDefault("Enchanted weapons have more power");
			//Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}
