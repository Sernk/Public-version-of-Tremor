using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Mounts;

namespace TremorMod.Content.Buffs
{
	public class FatSpider : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			// DisplayName.SetDefault("Fat Spider");
			// Description.SetDefault("Cute human-eater");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(ModContent.MountType<Spider>(), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
