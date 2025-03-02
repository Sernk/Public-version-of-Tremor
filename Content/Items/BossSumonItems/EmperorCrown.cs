using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.NPCs.Bosses.TheDarkEmperor;

namespace TremorMod.Content.Items.BossSumonItems
{
	public class EmperorCrown : ModItem
	{
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
			//DisplayName.SetDefault("Emperor Crown");
			//Tooltip.SetDefault("Summons the Dark Emperor\n" +
			//"Requires Tremode");
		}

		public override bool CanUseItem(Player player)
		{
			return NPC.downedMoonlord && !NPC.AnyNPCs(ModContent.NPCType<TheDarkEmperor>());
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SlimeCrown, 1);
			recipe.AddIngredient(ModContent.ItemType<Doomstone>(), 9);
			recipe.AddIngredient(ModContent.ItemType<DarkMass>(), 3);
			//recipe.SetResult(this);
			recipe.AddTile(26);
			recipe.Register();
		}

		public override bool? UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<TheDarkEmperor>());
            SoundEngine.PlaySound(SoundID.Roar, player.position); // Play a sound at the player's position
            return true;
		}
	}
}
