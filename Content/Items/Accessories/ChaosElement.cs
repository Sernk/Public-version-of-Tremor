using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using TremorMod.Content;
using TremorMod.Content.Buffs;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Accessories
{
	public class ChaosElement : ModItem
	{

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chaos Element");
			Tooltip.SetDefault("Flasks spawn crystal splinters when destroyed\n" +
			"Splinters heal you when hit enemy");
		}*/

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 22;
			Item.value = 100000;
			Item.rare = 5;
			Item.defense = 3;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(ModContent.BuffType<ChaosElementBuff>(), 2);
			if (player.GetModPlayer<MPlayer>().alchemicalCrit >= 30)
			{
				player.GetModPlayer<MPlayer>().alchemicalDamage += 0.1f;
			}
		}
	}
}