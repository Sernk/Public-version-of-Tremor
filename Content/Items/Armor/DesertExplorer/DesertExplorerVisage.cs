using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Content.Buffs;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.DesertExplorer
{
	[AutoloadEquip(EquipType.Head)]
	public class DesertExplorerVisage : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 22;
			Item.value = 15000;
			Item.rare = 8;
			Item.defense = 11;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Desert Explorer Visage");
			// Tooltip.SetDefault("15% increased alchemical critical strike chance");
            //TremorGlowMask.AddGlowMask(item.type, $"{typeof(DesertExplorerVisage).NamespaceToPath()}/DesertExplorerVisage_HeadGlow");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("When a flask explodes a wasp appears to attack enemies");
        }

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowSubtle = true;
			player.armorEffectDrawOutlines = true;
		}

		public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
		{
			glowMaskColor = Color.White;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>().alchemicalCrit += 15;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<DesertExplorerBreastplate>() && legs.type == ModContent.ItemType<DesertExplorerGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "When a flask explodes a wasp appears to attack enemies";
			player.AddBuff(ModContent.BuffType<DesertEmperorSetBuff>(), 4);
		}
	}
}
