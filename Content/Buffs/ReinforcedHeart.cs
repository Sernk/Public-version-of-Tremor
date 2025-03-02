using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class ReinforcedHeart : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			//DisplayName.SetDefault("Reinforced Heart");
			//Description.SetDefault("Increases maximum health");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.statLifeMax2 += 100;
		}
	}
}
