using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class PyroBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("The Pyro");
			//Description.SetDefault("Alchemical projectiles leave an explosion instead of clouds");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}