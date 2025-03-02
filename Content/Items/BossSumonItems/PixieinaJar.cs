using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.NPCs.Bosses.PixieQueen;

namespace TremorMod.Content.Items.BossSumonItems
{
	public class PixieinaJar : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 30;
			Item.maxStack = 20;

			Item.rare = 5;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = 4;
			Item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Pixie in a Jar");
			/* Tooltip.SetDefault("Summons the Pixie Queen\n" +
			"Requires any mech. boss to have been slain, the the hallow biome and night time\n" +
			"'I think something wants to get out of the jar...'"); */
		}

		public override bool CanUseItem(Player player)
		{
			return NPC.downedMechBossAny && !Main.dayTime && !NPC.AnyNPCs(ModContent.NPCType<PixieQueen>()) && player.ZoneHallow;
		}

		public override bool? UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<PixieQueen>());
			SoundEngine.PlaySound(SoundID.Roar, player.position);
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Bottle, 1);
			recipe.AddIngredient(ItemID.PixieDust, 25);
			recipe.AddIngredient(ItemID.SoulofLight, 15);
			recipe.AddIngredient(ItemID.CrystalShard, 20);
			recipe.AddIngredient(ItemID.HallowedBar, 6);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
