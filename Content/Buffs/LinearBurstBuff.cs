using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class LinearBurstBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Linear Burst");
			//Description.SetDefault("Alchemical projectiles leave five death flames");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}