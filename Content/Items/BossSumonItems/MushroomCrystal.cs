using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.NPCs.Bosses.FungusBeetle;

namespace TremorMod.Content.Items.BossSumonItems
{
	public class MushroomCrystal : ModItem
	{

		public override void SetDefaults()
		{

			Item.width = 24;
			Item.height = 24;
			Item.maxStack = 20;
			Item.value = 100;
			Item.rare = 3;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useStyle = 4;
			Item.consumable = true;

		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Mushroom Crystal");
			/* Tooltip.SetDefault("Summons Fungus Beetle\n" +
			"Requires EoW or BoC to have been slain"); */
		}

		public override bool CanUseItem(Player player)
		{
			return NPC.downedBoss3 && !NPC.AnyNPCs(ModContent.NPCType<FungusBeetle>());
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.GlowingMushroom, 15);
			recipe.AddIngredient(ModContent.ItemType<Gloomstone>(), 8);
			recipe.AddIngredient(ItemID.StoneBlock, 10);
			recipe.AddIngredient(ItemID.Sapphire, 12);
			recipe.AddTile(16);
			recipe.Register();
		}

		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
		{
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<FungusBeetle>());
			SoundEngine.PlaySound(SoundID.Roar, player.position);
			return true;
		}
	}
}