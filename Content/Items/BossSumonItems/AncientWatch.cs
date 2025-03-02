using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;
using TremorMod.Content.Event;
using TremorMod.Content.Items.BossLoot.TheDarkEmperor;
using TremorMod.Content.NPCs.Invasion.ParadoxTitan;
using TremorMod.Content.NPCs.Invasion;

namespace TremorMod.Content.Items.BossSumonItems
{
	public class AncientWatch : ModItem
	{
		public override void SetDefaults()
		{

			Item.width = 40;
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
			// DisplayName.SetDefault("Ancient Watch");
			// Tooltip.SetDefault("Summons Paradox Cohort");
		}

		public override bool CanUseItem(Player player)
		{
			CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>();
			if (InvasionWorld.CyberWrath)
				return false;
			return true;
		}

		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
		{
			CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>();
			Main.NewText("Paradox Cohort is striking from nowhere!", 39, 86, 134);
			//SoundEngine.PlaySound(ModContent.GetSoundSlot(SoundType.Music, "Sounds/Music/Wrath1"), (int)player.position.X, (int)player.position.Y, 0);
			SoundEngine.PlaySound(SoundID.Roar, player.position);
			if (Main.netMode != 1)
			{
				NPC.NewNPC(Item.GetSource_FromThis(), (int)player.Center.X, (int)player.Center.Y - 200, ModContent.NPCType<Titan_>());
			}
			InvasionWorld.CyberWrath = true;
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<NightmareBar>(), 5);
			recipe.AddIngredient(ModContent.ItemType<SoulofFight>(), 3);
			recipe.AddIngredient(ItemID.Glass, 5);
			recipe.AddIngredient(ModContent.ItemType<HuskofDusk>(), 2);
			recipe.AddIngredient(ModContent.ItemType<LapisLazuli>(), 1);
			recipe.AddTile(ModContent.TileType<StarvilTile>());
			recipe.Register();
		}
	}
}
