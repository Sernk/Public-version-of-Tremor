using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class BottledSoulOfLightBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			// DisplayName.SetDefault("Bottled Soul of Light");
			// Description.SetDefault("20% increased movement speed");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.moveSpeed += 0.2f;
		}
	}
}
