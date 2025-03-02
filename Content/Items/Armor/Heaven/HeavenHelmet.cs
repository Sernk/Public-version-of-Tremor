using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace TremorMod.Content.Items.Armor.Heaven
{
	[AutoloadEquip(EquipType.Head)]
	public class HeavenHelmet : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{

			Item.width = 32;
			Item.height = 26;

			Item.value = 6000;
			Item.rare = 3;
			Item.defense = 6;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Heaven Helmet");
			// Tooltip.SetDefault("Increases ranged critical strike chance by 12");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Grants immunity to most debuffs");
        }

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Ranged) += 12;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<HeavenBreastplate>() && legs.type == ModContent.ItemType<HeavenLeggings>();
		}

		public override void UpdateArmorSet(Player p)
		{
            p.setBonus = SetBonusText.Value;
            p.setBonus = "Grants immunity to most debuffs";
			p.buffImmune[44] = true; //Frostburn
			p.buffImmune[46] = true; //Chilled
			p.buffImmune[47] = true; //Frozen
			p.buffImmune[20] = true; //Poisoned
			p.buffImmune[22] = true; //Darkness
			p.buffImmune[24] = true; //Fire
			p.buffImmune[23] = true; //Cursed
			p.buffImmune[30] = true; //Bleeding
			p.buffImmune[31] = true; //Confused
			p.buffImmune[32] = true; //Slowed
			p.buffImmune[33] = true; //Weak
			p.buffImmune[35] = true; //Silenced
			p.buffImmune[36] = true; //Broken Armor
			p.buffImmune[69] = true; //Ichor
			p.buffImmune[70] = true; //Venom
			p.buffImmune[80] = true; //Black Out
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowSubtle = true;
		}

	}
}
