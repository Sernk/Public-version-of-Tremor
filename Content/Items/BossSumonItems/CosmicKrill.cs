using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using System.Collections.Generic;
using Terraria.DataStructures;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;
using TremorMod.Content.NPCs.Bosses.SpaceWhale;

namespace TremorMod.Content.Items.BossSumonItems
{
	public class CosmicKrill : ModItem
	{
		const int XOffset = -400;
		const int YOffset = -400;

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 28;
			Item.maxStack = 20;
			Item.value = 100;
			Item.rare = 11;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useStyle = 4;
			Item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Cosmic Krill");
			//Tooltip.SetDefault("Summons the Space Whale\n" +
			//"Requires Tremode");
		}

        public override bool CanUseItem(Player player)
        {
			return NPC.downedMoonlord && !NPC.AnyNPCs(ModContent.NPCType<SpaceWhale>());
		}

        public override bool? UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<SpaceWhale>());
            Main.NewText("Space Whale has awoken!", 175, 75, 255);
            SoundEngine.PlaySound(SoundID.Item15, player.position);
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Shrimp, 1);
			recipe.AddIngredient(ModContent.ItemType<StarBar>(), 16);
			recipe.AddIngredient(ModContent.ItemType<Phantaplasm>(), 16);
			//recipe.SetResult(this);
			recipe.AddTile(ModContent.TileType<StarvilTile>());
			recipe.Register();
		}
	}
}
