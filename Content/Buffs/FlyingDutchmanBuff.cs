using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Mounts;

namespace TremorMod.Content.Buffs
{
	public class FlyingDutchmanBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			//DisplayName.SetDefault("Flying Dutchman");
			//Description.SetDefault("Flies like a butterfly!");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(ModContent.MountType<FlyingDutchman>(), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
