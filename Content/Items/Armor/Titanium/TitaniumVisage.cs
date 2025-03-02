using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.Titanium
{
	[AutoloadEquip(EquipType.Head)]
	public class TitaniumVisage : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 24;
			Item.value = 400;
			Item.rare = 4;
			Item.defense = 9;
		}

		public override void SetStaticDefaults()
		{
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Become invulnerable after striking an enemy\n" +
			"20% increased alchemical critical strike chance");
            // DisplayName.SetDefault("Titanium Visage");
			// Tooltip.SetDefault("24% increased alchemical damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.24f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 1218 && legs.type == 1219;
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Become invulnerable after striking an enemy\n" +
			"20% increased alchemical critical strike chance";
			player.GetModPlayer<MPlayer>().alchemicalCrit += 20;
			player.onHitDodge = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TitaniumBar, 10);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
