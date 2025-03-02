using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class DripplerBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//Main.buffNoTimeDisplay[Type] = true;
			// DisplayName.SetDefault("Drippler");
			// Description.SetDefault("It flies. And flows.");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(Mod.Find<ModMount>("DripplerMount").Type, player);
			player.buffTime[buffIndex] = 10;
			player.slowFall = true;
		}
	}
}
