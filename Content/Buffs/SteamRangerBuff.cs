using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class SteamRangerBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Brass Ranged Enchanting");
			//Description.SetDefault("Increases Brass Chain Repeater damage");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}