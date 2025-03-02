using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Buffs
{
	public class ManaSaving : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Mana Saving");
			//Description.SetDefault("Mana cost is reduced by 50%");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.manaCost -= 0.50f;
		}
	}
}