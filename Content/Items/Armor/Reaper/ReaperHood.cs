using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.Reaper
{
	[AutoloadEquip(EquipType.Head)]
	public class ReaperHood : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 22;
			Item.value = 10000;
			Item.rare = 5;
			Item.defense = 8;
		}

		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Reaper Hood");
            //Tooltip.SetDefault("15% increased alchemical damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("30% increased alchemical critical strike chance");
        }

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.15f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<ReaperBreastplate>() && legs.type == ModContent.ItemType<ReaperGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "30% increased alchemical critical strike chance";
			player.GetModPlayer<MPlayer>().alchemicalCrit += 30;
		}
	}
}
