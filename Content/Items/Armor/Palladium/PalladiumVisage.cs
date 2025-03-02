using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.Palladium
{
	[AutoloadEquip(EquipType.Head)]
	public class PalladiumVisage : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 20;
			Item.value = 400;
			Item.rare = 4;
			Item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Palladium Visage");
            //Tooltip.SetDefault("18% increased alchemical damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("12% increased alchemical critical strike chance and greatly increases life regeneration after striking an enemy");
        }

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.18f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 1208 && legs.type == 1209;
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Greatly increases life regeneration after striking an enemy\n" +
			"12% increased alchemical critical strike chance";
			player.GetModPlayer<MPlayer>().alchemicalCrit += 12;
			player.onHitRegen = true;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.PalladiumBar, 10);
			//recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.Register();
		}
	}
}
