using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace TremorMod.Content.Items.Armor.Orcish
{
	[AutoloadEquip(EquipType.Head)]
	public class OrcishHelmet : ModItem
	{
		public static LocalizedText SetBonusText { get; private set; }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 26;
			Item.value = 400;
			Item.rare = 1;
			Item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			/*DisplayName.SetDefault("Orcish Helmet");
			Tooltip.SetDefault("7% increased melee damage");*/
			SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increased maximum defense by 2");
		}

		public override void UpdateEquip(Player player)
		{
            player.GetDamage(DamageClass.Melee) += 0.07f;   // +7% к ближнему урону
        }

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<OrcishBreastplate>() && legs.type == ModContent.ItemType<OrcishGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = Language.GetTextValue("TremorMod.ArmorSetBonus");
			player.statDefense += 2;
		}
	}
}
