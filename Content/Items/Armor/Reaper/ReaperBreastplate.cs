using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.Reaper
{
	[AutoloadEquip(EquipType.Body)]
	public class ReaperBreastplate : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = 5;
			Item.defense = 9;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Reaper Breastplate");
			//Tooltip.SetDefault("15% increased alchemical damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.15f;
		}
	}
}