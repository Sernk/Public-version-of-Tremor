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
	[AutoloadEquip(EquipType.Legs)]
	public class HadesGreaves : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = 500;
			Item.rare = 1;
			Item.defense = 42;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Hades Greaves");
			//Tooltip.SetDefault("Increases movement speed\n" +
			//"Allows to dash\n" +
			//"Double tap a direction\n" +
			//"Allows you to walk on liquids");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<InfernoSoul>(), 7);
			recipe.AddIngredient(ModContent.ItemType<MagmoniumGreaves>(), 1);
			recipe.AddIngredient(ModContent.ItemType<FireFragment>(), 17);
			recipe.AddIngredient(ModContent.ItemType<Phantaplasm>(), 10);
			recipe.AddIngredient(ItemID.LivingFireBlock, 8);
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
            player.GetModPlayer<HadesDashPlayer>().DashAccessoryEquipped = true;
            player.moveSpeed += 0.8f;
			player.dash = 1;
			player.waterWalk = true;
		}
	}
}