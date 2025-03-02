using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class NitroBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("The Nitro");
			//Description.SetDefault("Alchemical projectiles leave death flames");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}