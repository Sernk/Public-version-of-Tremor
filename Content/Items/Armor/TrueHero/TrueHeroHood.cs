using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Armor.TrueHero
{
	[AutoloadEquip(EquipType.Head)]
	public class TrueHeroHood : ModItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetDefaults()
		{

			Item.width = 32;
			Item.height = 26;
			Item.value = 25000;

			Item.rare = 0;
			Item.defense = 15;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("True Hero Hood");
			// Tooltip.SetDefault("Gives one of three true blades");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Increases maximum defense by 20");
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (var tooltip in tooltips)
            {
                if (tooltip.Mod == "Terraria" && tooltip.Name == "ItemName")
                {
                    tooltip.OverrideColor = new Color(238, 194, 73);
                }
            }
        }

        public override void UpdateEquip(Player player)
		{
			player.AddBuff(ModContent.BuffType<FirstTrueBlade>(), 2);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<TrueHeroShirt>() && legs.type == ModContent.ItemType<TrueHeroPants>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = SetBonusText.Value;
            player.setBonus = "Increases maximum defense by 20";
			player.statDefense += 20;
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(247, 1);
            recipe.AddIngredient(ModContent.ItemType<GiantShell>(), 1);
            recipe.AddIngredient(ModContent.ItemType<BrokenHeroArmorplate>(), 1);
            recipe.AddIngredient(ModContent.ItemType<TrueEssense>(), 5);
            //recipe.SetResult(this);
            recipe.AddTile(412);
            recipe.Register();
        }
    }
}
