using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.NPCsDrop
{
	public class OceanAmulet : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 34;
			Item.rare = 5;
			Item.accessory = true;
			Item.value = 50000;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ocean Amulet");
			Tooltip.SetDefault("Extends underwater breathing\n" +
			"Increases fishing skill by 12 and allows to detect catched fish");
		}*/

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.fishingSkill += 12;
			player.accDivingHelm = true;
			player.AddBuff(122, 60, true);
		}
	}
}
