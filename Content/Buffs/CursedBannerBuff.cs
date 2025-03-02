using Terraria;
using Terraria.ModLoader;
using TremorMod.Utilities;

namespace TremorMod.Content.Buffs
{
	public class CursedBannerBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("The Cursed Banner");
			// Description.SetDefault("Increases all critical strike chance by 25");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetCritChance(DamageClass.Melee) += 25;
			player.GetCritChance(DamageClass.Ranged) += 25;
			player.GetCritChance(DamageClass.Magic) += 25;
			player.GetCritChance(DamageClass.Throwing) += 25;
			player.GetModPlayer<MPlayer>().alchemicalCrit += 25;
		}
	}
}