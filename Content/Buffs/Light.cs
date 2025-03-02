using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class Light : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Light Spell");
			// Description.SetDefault("");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetAttackSpeed(DamageClass.Melee) += 0.03f;
			player.detectCreature = true;
			player.findTreasure = true;
			player.GetDamage(DamageClass.Melee) += 0.03f;
			player.GetDamage(DamageClass.Ranged) += 0.03f;
			player.GetDamage(DamageClass.Throwing) += 0.03f;
			player.GetDamage(DamageClass.Summon) += 0.03f;
			player.GetDamage(DamageClass.Magic) += 0.03f;
			player.moveSpeed += 0.2f;
			player.GetCritChance(DamageClass.Ranged) += 2;
			player.GetCritChance(DamageClass.Melee) += 2;
			player.GetCritChance(DamageClass.Magic) += 2;
			player.GetCritChance(DamageClass.Throwing) += 2;
			player.jumpSpeedBoost += 0.2f;
		}
	}
}