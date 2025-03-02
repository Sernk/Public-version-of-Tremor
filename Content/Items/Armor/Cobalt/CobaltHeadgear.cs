using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.Cobalt
{
	[AutoloadEquip(EquipType.Head)]
	public class CobaltHeadgear : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{

			Item.width = 20;
			Item.height = 26;

			Item.value = 400;
			Item.rare = 4;
			Item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Cobalt Headgear");
			// Tooltip.SetDefault("18% increased minion damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increases your max number of minions");
        }

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Summon) += 0.18f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 374 && legs.type == 375;
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Increases your max number of minions";
			player.maxMinions += 1;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CobaltBar, 12);
			recipe.AddTile(16);
			recipe.Register();
		}
	}
}
