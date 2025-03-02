using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class BottledSoulOfSightBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			// DisplayName.SetDefault("Bottled Soul of Sight");
			// Description.SetDefault("Shows the location of enemies");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.detectCreature = true;
		}
	}
}
