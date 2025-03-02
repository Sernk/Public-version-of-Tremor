using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class BottledSoulOfMindBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			// DisplayName.SetDefault("Bottled Soul of Mind");
			// Description.SetDefault("Shows the location of treasure and ore");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.findTreasure = true;
		}
	}
}
