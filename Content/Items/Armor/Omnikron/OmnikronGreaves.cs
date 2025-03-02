using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.Omnikron
{
	[AutoloadEquip(EquipType.Legs)]
	public class OmnikronGreaves : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 22;
			Item.value = 0;
			Item.rare = 0;
			Item.defense = 24;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Omnikron Greaves");
			//Tooltip.SetDefault("50% increased movement speed\n" +
			//"Increases all critical strike chances by 15");
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
			player.moveSpeed += 0.5f;
            player.GetCritChance(DamageClass.Generic) += 15;
			player.GetModPlayer<MPlayer>().alchemicalCrit += 15;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<OmnikronBar>(), 18);
			//recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.Register();
		}

	}
}
