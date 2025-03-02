using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class BouncingCasingBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Bouncing Casing");
            //Description.SetDefault("Alchemical flasks bounce off walls");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }
	}
}