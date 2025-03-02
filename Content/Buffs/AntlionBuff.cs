using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Mounts;

namespace TremorMod.Content.Buffs
{
	public class AntlionBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			//DisplayName.SetDefault("Antlion");
			//Description.SetDefault("It likes your sugar");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(ModContent.MountType<Antlion>(), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
