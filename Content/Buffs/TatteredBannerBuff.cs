using Terraria;
using Terraria.ModLoader;
using TremorMod.Utilities;

namespace TremorMod.Content.Buffs
{
	public class TatteredBannerBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("The Tattered Banner");
			// Description.SetDefault("25% increased damage");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetDamage(DamageClass.Melee) += 0.25f;
			player.GetDamage(DamageClass.Ranged) += 0.25f;
			player.GetDamage(DamageClass.Summon) += 0.25f;
			player.GetDamage(DamageClass.Magic) += 0.25f;
			player.GetDamage(DamageClass.Throwing) += 0.25f;
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.25f;
		}
	}
}