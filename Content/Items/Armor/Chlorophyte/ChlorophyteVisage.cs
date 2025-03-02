using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.Chlorophyte
{
	[AutoloadEquip(EquipType.Head)]
	public class ChlorophyteVisage : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{

			Item.width = 24;
			Item.height = 22;

			Item.value = 60000;
			Item.rare = 7;
			Item.defense = 13;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Chlorophyte Visage");
			// Tooltip.SetDefault("29% increased alchemical damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Summons a powerful leaf crystal to shoot at nearby enemies 25% increased alchemical critical strike chance");
        }

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.29f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 1004 && legs.type == 1005;
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Summons a powerful leaf crystal to shoot at nearby enemies\n" +
"25% increased alchemical critical strike chance";
			player.GetModPlayer<MPlayer>().alchemicalCrit += 25;
			player.AddBuff(60, 60, true);
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
