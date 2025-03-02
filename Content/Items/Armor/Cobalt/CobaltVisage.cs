using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.Cobalt
{
	[AutoloadEquip(EquipType.Head)]
	public class CobaltVisage : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{

			Item.width = 26;
			Item.height = 22;

			Item.value = 400;
			Item.rare = 4;
			Item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Cobalt Visage");
			// Tooltip.SetDefault("18% increased alchemical damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("12% increased alchemical critical strike chance");
        }

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.18f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 374 && legs.type == 375;
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "12% increased alchemical critical strike chance";
			player.GetModPlayer<MPlayer>().alchemicalCrit += 12;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CobaltBar, 10);
			recipe.AddTile(16);
			recipe.Register();
		}
	}
}
