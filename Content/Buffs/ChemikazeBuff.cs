using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class ChemikazeBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("The Chemikaze");
			//Description.SetDefault("Alchemical projectiles leave five explosions");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}