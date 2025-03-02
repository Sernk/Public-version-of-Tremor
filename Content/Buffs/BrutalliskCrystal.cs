using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Mounts;

namespace TremorMod.Content.Buffs
{
	public class BrutalliskCrystal : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			//DisplayName.SetDefault("Aquamarine Crystal");
			//Description.SetDefault("A fast way of travelling");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(ModContent.MountType<BrutalliskCrystalMounts>(), player);
			player.buffTime[buffIndex] = 10;
			player.noKnockback = true;
		}
	}
}
