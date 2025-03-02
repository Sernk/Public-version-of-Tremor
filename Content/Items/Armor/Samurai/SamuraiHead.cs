using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Armor.Samurai
{
	[AutoloadEquip(EquipType.Head)]
	public class SamuraiHead : ModItem
	{

        public static LocalizedText SetBonusText { get; private set; }

        public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.value = 100000;
			Item.rare = 5;
			Item.defense = 10;
		}

		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Samurai Helmet");
            //Tooltip.SetDefault("9% increased damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Greatly increased life regeneration!");
        }

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Generic) += 0.09f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<SamuraiChestplate>() && legs.type == ModContent.ItemType<SamuraiGeaves>();
		}
		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Greatly increased life regeneration!";
			player.crimsonRegen = true;

		}

	}
}
