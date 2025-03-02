using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class JellyBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Jellyfish Buff");
			//Description.SetDefault("The jellyfish will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}