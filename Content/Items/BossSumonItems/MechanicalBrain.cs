using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.NPCs.Bosses.Motherboard;

namespace TremorMod.Content.Items.BossSumonItems
{
	public class MechanicalBrain : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 18;
			Item.maxStack = 20;

			Item.rare = 5;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = 4;
			Item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Mechanical Brain");
			/* Tooltip.SetDefault("Summons the Motherboard\n" +
			"Requires hardmode and night time"); */
		}

		public override bool CanUseItem(Player player)
		{
			return Main.hardMode && !Main.dayTime && !NPC.AnyNPCs(ModContent.NPCType<Motherboard>());
		}

		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
		{
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<Motherboard>());
			SoundEngine.PlaySound(SoundID.Roar, player.position);
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Vertebrae, 6);
			recipe.AddIngredient(ItemID.IronBar, 6);
			recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
