using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class NightHunting : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Night Hunting");
			//Description.SetDefault("Increases all stats during night");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (!Main.dayTime)
			{
				player.GetDamage(DamageClass.Generic) += 0.15f;
				player.GetCritChance(DamageClass.Generic) += 12;
				player.moveSpeed += 0.25f;
			}
		}
	}
}
