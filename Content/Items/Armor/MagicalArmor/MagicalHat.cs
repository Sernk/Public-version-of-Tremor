using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace TremorMod.Content.Items.Armor.MagicalArmor
{
	[AutoloadEquip(EquipType.Head)]
	public class MagicalHat : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{

			Item.width = 26;
			Item.height = 22;

			Item.value = 250;
			Item.rare = 1;
			Item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Theurgic Hat");
			// Tooltip.SetDefault("3% increased magic damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increases maximum mana by 20");
        }

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Magic) += 0.03f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<MagicalRobe>() && legs.type == ModContent.ItemType<MagicalGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Increases maximum mana by 20";
			player.statManaMax2 += 20;
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Silk, 7);
            recipe.AddIngredient(ItemID.LeadBar, 3);
            recipe.AddTile(18);
            recipe.Register();

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.Silk, 7);
            recipe1.AddIngredient(ItemID.IronBar, 3);
            recipe1.AddTile(18);
            recipe1.Register();

        }

    }
}
