using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using Terraria.Localization;

namespace TremorMod.Content.Items.Armor.Flesh
{
	[AutoloadEquip(EquipType.Head)]
	public class FleshHeadgear : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 22;
			Item.value = 18000;
			Item.rare = 1;
			Item.defense = 7;
		}

        public override void SetStaticDefaults()
		{
			 /*DisplayName.SetDefault("Flesh Headgear");
			Tooltip.SetDefault("9% increased minion damage\n" +
			"Increases your max number of minions");*/
		    SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increases regeneration!");
		}

        public override void UpdateEquip(Player player)
		{
            player.GetDamage(DamageClass.Summon) += 0.09f;
            player.maxMinions += 1;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<FleshBreastplate>() && legs.type == ModContent.ItemType<FleshGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increases regeneration!");
			player.crimsonRegen = true;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PieceofFlesh>(), 4);
            //recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.Register();
        }

	}
}
