using Terraria;
using Terraria.ModLoader;
using TremorMod.Utilities;

namespace TremorMod.Content.Buffs
{
	public class FlaskCoreBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Flask Core");
			// Description.SetDefault("Flasks now have autoreuse");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            MPlayer modPlayer = player.GetModPlayer<MPlayer>();
            modPlayer.core = true;
        }
	}
}