using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class ChaosElementBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Chaos Element");
			//Description.SetDefault("Flasks summon crystal splinters that heal you when hit enemy");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}