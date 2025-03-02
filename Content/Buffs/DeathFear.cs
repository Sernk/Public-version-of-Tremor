using Terraria;
using Terraria.ModLoader;
using TremorMod.Utilities; 

namespace TremorMod.Content.Buffs
{
	public class DeathFear : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Death Fear");
			//Description.SetDefault("Frightened, the victim loses his life");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
            //BuffID.Sets.LongerExpertDebuff[< BuffType >] = true;
        }

        public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<TremorPlayer>().dFear = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<TremorGlobalNPC>().dFear = true;
		}

	}
}
