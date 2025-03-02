using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using TremorMod;
using TremorMod.Content.Buffs;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.CogLordItems
{
	public class BrassChip : ModItem
	{
		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brass Chip");
			Tooltip.SetDefault("Shoots rockets from the sky when a flask is destroyed\n" +
			"If alchemical critical strike chance is more than 30 - alchemical damage is increased by 10%");
		}*/

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 22;
			Item.value = 150000;
			Item.rare = 5;
			Item.defense = 4;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(ModContent.BuffType<BrassChipBuff>(), 2);
			if (player.GetModPlayer<MPlayer>().alchemicalCrit >= 30)
			{
				player.GetModPlayer<MPlayer>().alchemicalDamage += 0.1f;
			}
		}
	}
}