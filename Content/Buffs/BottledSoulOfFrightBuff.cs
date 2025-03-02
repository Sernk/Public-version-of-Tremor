using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class BottledSoulOfFrightBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			// DisplayName.SetDefault("Bottled Soul of Fright");
			// Description.SetDefault("Increases critical strike chance by 2");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetCritChance(DamageClass.Ranged) += 2;
			player.GetCritChance(DamageClass.Melee) += 2;
			player.GetCritChance(DamageClass.Magic) += 2;
			player.GetCritChance(DamageClass.Throwing) += 2;
		}
	}
}
