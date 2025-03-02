using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class HungryBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Hungry");
			//Description.SetDefault("The hungry will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}