using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;
using TremorMod.Content.Event;

namespace TremorMod.Content.Items.BossSumonItems
{
	public class ScrollofUndead : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 40;
			Item.height = 28;
			Item.maxStack = 20;
			Item.value = 100;
			Item.rare = 3;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.useStyle = 4;
			Item.consumable = true;

		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Scroll of Undead");
			// Tooltip.SetDefault("Begins the Night of the Undead");
		}

		public override bool CanUseItem(Player player)
		{
			/*CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>(mod);
			if (ZWorld.ZInvasion)
			{
				return false;
			}*/

			if (Main.dayTime)
			{
				return false;
			}
			return true;
		}

		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
		{
			//CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>();
			Main.NewText("Undead creatures are rising from ground!", 175, 75, 255);
			Main.NewText("The Night of Undead has begun...", 135, 17, 17);
			ZWorld.ZInvasion = true;
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<TornPapyrus>(), 3);
			recipe.AddIngredient(ModContent.ItemType<BottledGlue>(), 2);
			recipe.AddIngredient(ModContent.ItemType<UntreatedFlesh>(), 5);
			recipe.AddIngredient(ItemID.Amethyst, 4);
			recipe.AddTile(ModContent.TileType<FleshWorkstationTile>());
			recipe.Register();
		}
	}
}
