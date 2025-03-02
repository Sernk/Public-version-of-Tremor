using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class ConcentratedTinctureBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Concentrated Tincture");
			//Description.SetDefault("Increases life regeneration from healing flasks");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}