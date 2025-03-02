using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace TremorMod.Content.Items.Armor.Vicious
{
	[AutoloadEquip(EquipType.Head)]
	public class ViciousHelmet : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{

			Item.width = 38;
			Item.height = 22;

			Item.value = 30000;
			Item.rare = 1;
			Item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Vicious Helmet");
			/* Tooltip.SetDefault("6% increased minion damage\n" +
			"Increases your max number of minions"); */
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increased maximum defense by 2");
        }

		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 1;
			player.GetDamage(DamageClass.Summon) += 0.06f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<ViciousChestplate>() && legs.type == ModContent.ItemType<ViciousLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Increased maximum defense by 2";
			player.statDefense += 3;
		}

	}
}
