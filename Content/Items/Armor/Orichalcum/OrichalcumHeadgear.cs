using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace TremorMod.Content.Items.Armor.Orichalcum
{
	[AutoloadEquip(EquipType.Head)]
	public class OrichalcumHeadgear : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 26;
			Item.value = 400;
			Item.rare = 4;
			Item.defense = 6;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Orichalcum Headgear");
			//Tooltip.SetDefault("20% increased minion damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increases your max number of minions and flower petals will fall on your target for extra damage");
        }

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Summon) += 0.20f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 1213 && legs.type == 1214;
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Increases your max number of minions and flower petals will fall on your target for extra damage";
			player.maxMinions += 2;
			player.onHitPetal = true;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowSubtle = true;
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
