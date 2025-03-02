using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.CraftingStations
{
	public class DivineForge : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 50;
			Item.height = 26;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.rare = 11;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.value = 150;
			Item.createTile = ModContent.TileType<DivineForgeTile>();
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Divine Forge");
			//Tooltip.SetDefault("Combines the function of the anvil, furnace and the ancient manipulator\n" +
			//"Allows you to work with heavenly materials");
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

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<CollapsiumOre>(), 30);
			recipe.AddIngredient(ModContent.ItemType<AngeliteOre>(), 30);
			recipe.AddIngredient(ModContent.ItemType<OmnikronBar>(), 5);
			recipe.AddIngredient(ItemID.MythrilAnvil, 1);
			recipe.AddIngredient(ItemID.AdamantiteForge, 1);
			recipe.AddIngredient(ModContent.ItemType<TrueEssense>(), 10);
			recipe.AddIngredient(3549, 1);
			recipe.AddTile(ModContent.TileType<StarvilTile>());
			//recipe.SetResult(this);
			recipe.Register();

			Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ModContent.ItemType<CollapsiumOre>(), 30);
            recipe1.AddIngredient(ModContent.ItemType<AngeliteOre>(), 30);
            recipe1.AddIngredient(ModContent.ItemType<OmnikronBar>(), 5);
            recipe1.AddIngredient(ItemID.OrichalcumAnvil, 1);
			recipe1.AddIngredient(ItemID.AdamantiteForge, 1);
            recipe1.AddIngredient(ModContent.ItemType<TrueEssense>(), 10);
            recipe1.AddIngredient(3549, 1);
            recipe1.AddTile(ModContent.TileType<StarvilTile>());
            //recipe1.SetResult(this);
			recipe1.Register();

			Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ModContent.ItemType<CollapsiumOre>(), 30);
            recipe2.AddIngredient(ModContent.ItemType<AngeliteOre>(), 30);
            recipe2.AddIngredient(ModContent.ItemType<OmnikronBar>(), 5);
            recipe2.AddIngredient(ItemID.OrichalcumAnvil, 1);
			recipe2.AddIngredient(ItemID.TitaniumForge, 1);
            recipe2.AddIngredient(ModContent.ItemType<TrueEssense>(), 10);
            recipe2.AddIngredient(3549, 1);
            recipe2.AddTile(ModContent.TileType<StarvilTile>());
            //recipe2.SetResult(this);
			recipe2.Register();

			Recipe recipe3 = CreateRecipe();
            recipe3.AddIngredient(ModContent.ItemType<CollapsiumOre>(), 30);
            recipe3.AddIngredient(ModContent.ItemType<AngeliteOre>(), 30);
            recipe3.AddIngredient(ModContent.ItemType<OmnikronBar>(), 5);
            recipe3.AddIngredient(ItemID.MythrilAnvil, 1);
			recipe3.AddIngredient(ItemID.TitaniumForge, 1);
            recipe3.AddIngredient(ModContent.ItemType<TrueEssense>(), 10);
            recipe3.AddIngredient(3549, 1);
            recipe3.AddTile(ModContent.TileType<StarvilTile>());
            //recipe3.SetResult(this);
			recipe3.Register();
		}
	}
}
