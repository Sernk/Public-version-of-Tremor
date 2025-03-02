using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Content.Items.Materials;
using TremorMod.Utilities;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Armor.Plague
{
	[AutoloadEquip(EquipType.Head)]
	public class PlagueHelmet : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{

			Item.width = 38;
			Item.height = 22;

			Item.value = 25000;
			Item.rare = 2;
			Item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Plague Helmet");
			// Tooltip.SetDefault("10% increased alchemical damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increases size of alchemical clouds");
        }

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.1f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<PlagueBreastplate>() && legs.type == ModContent.ItemType<PlagueGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Increases size of alchemical clouds";
			player.AddBuff(ModContent.BuffType<FlaskExpansionBuff>(), 2);
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Silk, 12);
            recipe.AddIngredient(ModContent.ItemType<PhantomSoul>(), 4);
            recipe.AddIngredient(ModContent.ItemType<TearsofDeath>(), 8);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}