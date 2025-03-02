using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class HuskyBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Husky");
			//Description.SetDefault("A husky will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}