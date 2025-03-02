using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class EyeMonolithBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			//DisplayName.SetDefault("Eye Monolith");
			//Description.SetDefault("15% increased summon damage");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetDamage(DamageClass.Summon) += 0.15f;
		}
	}
}
