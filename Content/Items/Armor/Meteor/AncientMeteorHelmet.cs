using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace TremorMod.Content.Items.Armor.Meteor
{
	[AutoloadEquip(EquipType.Head)]
	public class AncientMeteorHelmet : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }
        public override void SetDefaults()
		{

			Item.width = 20;
			Item.height = 26;

			Item.value = 9000;
			Item.rare = 1;
			Item.defense = 5;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ancient Meteor Helmet");
			// Tooltip.SetDefault("7% increased magic damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Reduces the mana cost of the Space Gun to zero");
        }

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Magic) += 0.07f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 124 && legs.type == 125;
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Reduces the mana cost of the Space Gun to zero";
			player.spaceGun = true;
		}
	}
}
