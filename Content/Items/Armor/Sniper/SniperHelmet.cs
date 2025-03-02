using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Buffs;
using Terraria.Localization;

namespace TremorMod.Content.Items.Armor.Sniper
{
	[AutoloadEquip(EquipType.Head)]
	public class SniperHelmet : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 26;
			Item.value = 1000000;
			Item.rare = 1;
			Item.defense = 36;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Sniper Helmet");
			/* Tooltip.SetDefault("15% increased ranged damage\n" +
			"20% decreased movement speed"); */
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increases projectile's speed twice");
        }

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == Mod.Find<ModItem>("SniperBreastplate").Type && legs.type == Mod.Find<ModItem>("SniperBoots").Type;
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Increases projectile's speed twice";
			player.moveSpeed += 0.15f;
			player.AddBuff(ModContent.BuffType<ShootSpeedBuff>(), 2);
			player.scope = true;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}

		public override void UpdateEquip(Player player)
		{
            player.GetDamage(DamageClass.Ranged) *= 1.15f;
			player.moveSpeed -= 0.20f;
		}
	}
}