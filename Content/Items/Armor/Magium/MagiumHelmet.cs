using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Materials.OreAndBar;

namespace TremorMod.Content.Items.Armor.Magium
{
	[AutoloadEquip(EquipType.Head)]
	public class MagiumHelmet : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 22;
			Item.value = 18000;
			Item.rare = 5;
			Item.defense = 8;
		}

		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Magium Helmet");
            //Tooltip.SetDefault("9% increased magic critical strike chance\n" +
            //"Increases maximum mana by 40");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("25% decreased mana cost");
        }

		public override void UpdateEquip(Player player)
		{			
            player.GetCritChance(DamageClass.Magic) += 9;
			player.statManaMax2 += 40;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<MagiumBreastplate>() && legs.type == ModContent.ItemType<MagiumGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = SetBonusText.Value;
			player.setBonus = "25% decreased mana cost";
			player.manaCost -= 0.25f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<RuneBar>(), 8);
			recipe.AddIngredient(ModContent.ItemType<MagiumShard>(), 6);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}