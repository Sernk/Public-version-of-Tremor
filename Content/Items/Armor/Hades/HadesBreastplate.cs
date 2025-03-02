using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Armor.Magmonium;
using TremorMod.Content.Items.AndasItems;
using TremorMod.Content.Tiles;
using TremorMod.Utilities;

namespace TremorMod.Content.Items.Armor.Hades
{
	[AutoloadEquip(EquipType.Body)]
	public class HadesBreastplate : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 18;
			Item.value = 600;
			Item.rare = 1;
			Item.defense = 56;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Hades Breastplate");
			//Tooltip.SetDefault("Increases maximum life by 50\n" +
			//"Increases defense when under 100 health\n" +
			//"45% increased damage");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<InfernoSoul>(), 10);
			recipe.AddIngredient(ModContent.ItemType<MagmoniumBreastplate>(), 1);
			recipe.AddIngredient(ModContent.ItemType<FireFragment>(), 19);
			recipe.AddIngredient(ModContent.ItemType<Phantaplasm>(), 13);
			recipe.AddIngredient(ItemID.LivingFireBlock, 12);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<StarvilTile>());
			recipe.Register();
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
			player.statLifeMax2 += 50;

			if (player.statLife < 100)
			{
				player.statDefense += 35;
			}
			player.GetDamage(DamageClass.Generic) += 0.45f;
			player.GetModPlayer<MPlayer>().alchemicalDamage += 0.45f;
		}
	}
}
