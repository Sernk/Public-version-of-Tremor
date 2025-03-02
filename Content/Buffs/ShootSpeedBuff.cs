using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class ShootSpeedBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Sniper's Accuracy");
			//Description.SetDefault("Increased projectile's speed twice");
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}
