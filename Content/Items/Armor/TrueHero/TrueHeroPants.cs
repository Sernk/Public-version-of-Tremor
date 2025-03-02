using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Items.Armor.TrueHero
{
	[AutoloadEquip(EquipType.Legs)]
	public class TrueHeroPants : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 22;
			Item.height = 18;
			Item.value = 25000;

			Item.rare = 0;
			Item.defense = 20;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("True Hero Pants");
			// Tooltip.SetDefault("Gives one of three true blades");
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
			player.AddBuff(ModContent.BuffType<ThirdTrueBlade>(), 2);
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(249, 1);
            recipe.AddIngredient(ModContent.ItemType<GiantShell>(), 1);
            recipe.AddIngredient(ModContent.ItemType<BrokenHeroArmorplate>(), 1);
            recipe.AddIngredient(ModContent.ItemType<TrueEssense>(), 3);
            //recipe.SetResult(this);
            recipe.AddTile(412);
            recipe.Register();
        }
    }
}
