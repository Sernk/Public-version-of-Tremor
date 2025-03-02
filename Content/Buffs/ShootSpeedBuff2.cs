using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class ShootSpeedBuff2 : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Paratrooper's Lens");
			//Description.SetDefault("Increased projectile's speed twice");
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}