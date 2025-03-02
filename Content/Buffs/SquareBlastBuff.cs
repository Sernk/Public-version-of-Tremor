using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class SquareBlastBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Square Blast");
			//Description.SetDefault("Alchemical projectiles leave explosions in the shape of square");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}