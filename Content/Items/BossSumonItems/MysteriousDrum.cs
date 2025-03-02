using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.NPCs.Bosses.TikiTotem;

namespace TremorMod.Content.Items.BossSumonItems
{
	public class MysteriousDrum : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 32;
			Item.maxStack = 20;
			Item.useTurn = true;
			Item.autoReuse = false;
			Item.useAnimation = 18;
			Item.useTime = 18;
			Item.useStyle = 4;
			Item.consumable = true;
			Item.value = 150;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Mysterious Drum");
			//Tooltip.SetDefault("Summons Tiki Totem\n" +
			//"Requires the jungle biome and night time");
		}

		public override bool CanUseItem(Player player)
		{
			return !Main.dayTime && player.ZoneJungle && !NPC.AnyNPCs(ModContent.NPCType<TikiTotem>());
		}

		public override bool? UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<TikiTotem>());
			SoundEngine.PlaySound(SoundID.Roar, player.position);
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.RichMahogany, 45);
			recipe.AddIngredient(ItemID.Stinger, 2);
			recipe.AddIngredient(ItemID.Rope, 25);
			recipe.AddIngredient(ItemID.ShadowScale, 8);
			recipe.AddIngredient(ItemID.Silk, 6);
			//recipe.SetResult(this);
			recipe.Register();

			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ItemID.RichMahogany, 45);
			recipe1.AddIngredient(ItemID.Stinger, 2);
			recipe1.AddIngredient(ItemID.Rope, 25);
			recipe1.AddIngredient(ItemID.TissueSample, 8);
			recipe1.AddIngredient(ItemID.Silk, 6);
			//recipe1.SetResult(this);
			recipe1.Register();
		}
	}
}
