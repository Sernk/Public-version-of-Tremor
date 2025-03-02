using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Armor.Paladin
{
	[AutoloadEquip(EquipType.Head)]
	public class PaladinHelmet : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 26;
			Item.value = 400;
			Item.rare = 10;
			Item.defense = 22;
		}

		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Paladin Helmet");
            //Tooltip.SetDefault("30% increased melee speed");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Summons a paladin hammer to protect you!");
        }

		public override void UpdateEquip(Player player)
		{
			player.GetAttackSpeed(DamageClass.Melee) += 0.30f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<PaladinBreastplate>() && legs.type == ModContent.ItemType<PaladinGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Summons a paladin hammer to protect you!";
			player.AddBuff(ModContent.BuffType<PaladinBuff>(), 2);
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true;
		}
	}
}
