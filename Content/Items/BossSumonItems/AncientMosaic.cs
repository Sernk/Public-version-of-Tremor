using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using TremorMod.Content.NPCs.Bosses.Alchemaster;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Items.BossSumonItems
{
	public class AncientMosaic : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 30;
			Item.height = 30;
			Item.maxStack = 1;

			Item.rare = 4;
			Item.maxStack = 20;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = 4;
			Item.UseSound = SoundID.Item44;
			Item.consumable = false;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ancient Mosaic");
			/* Tooltip.SetDefault("Summons the Alchemaster\n" +
"Requires hardmode and night time"); */
		}

		public override bool CanUseItem(Player player)
		{
			return !Main.dayTime && Main.hardMode && !NPC.AnyNPCs(ModContent.NPCType<Alchemaster>());
		}

		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
		{
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<Alchemaster>());
			SoundEngine.PlaySound(SoundID.Roar, player.position);
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<RedPuzzleFragment>(), 1);
			recipe.AddIngredient(ModContent.ItemType<GreenPuzzleFragment>(), 1);
			recipe.AddIngredient(ModContent.ItemType<YellowPuzzleFragment>(), 1);
			recipe.AddIngredient(ModContent.ItemType<PurplePuzzleFragment>(), 1);
			recipe.AddIngredient(ModContent.ItemType<BottledGlue>(), 1);
			recipe.AddTile(26);
			recipe.Register();
		}

	}
}
