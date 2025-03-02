using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Content.Items.Armor.Chain;
using TremorMod.Content.Items.Armor.Leather;
using TremorMod.Content.Items.Accessories;
using TremorMod.Content.Items.Materials;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.Chemist
{
	[AutoloadEquip(EquipType.Head)]
	public class ChemistHelmet : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{

			Item.width = 38;
			Item.height = 22;

			Item.value = 10000;
			Item.rare = 2;
			Item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Chemist Helmet");
			// Tooltip.SetDefault("6% increased alchemical damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("10% increased alchemical critical strike chance");
        }

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.06f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<ChemistJacket>() && legs.type == ModContent.ItemType<ChemistPants>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "10% increased alchemical critical strike chance";
			player.GetModPlayer<MPlayer>().alchemicalCrit += 10;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<LeatherHat>(), 1);
			recipe.AddIngredient(ModContent.ItemType<ChainCoif>(), 1);
			recipe.AddIngredient(ItemID.Goggles, 1);
			//recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.Register();
		}

	}
}
