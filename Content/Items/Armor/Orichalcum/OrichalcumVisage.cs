using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.Orichalcum
{
	[AutoloadEquip(EquipType.Head)]
	public class OrichalcumVisage : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 26;
			Item.value = 400;
			Item.rare = 4;
			Item.defense = 7;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Orichalcum Visage");
			//Tooltip.SetDefault("20% increased alchemical damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("16% increased alchemical critical strike chance and flower petals will fall on your target for extra damage");
        }

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.20f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 1213 && legs.type == 1214;
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Flower petals will fall on your target for extra damage\n" +
			"16% increased alchemical critical strike chance";
			player.GetModPlayer<MPlayer>().alchemicalCrit += 16;
			player.onHitPetal = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.OrichalcumBar, 12);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
