using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Fish
{
	public class Pumpfish : ModItem
	{
		public override void SetDefaults()
		{
			Item.questItem = true;
			Item.maxStack = 1;
			Item.width = 26;
			Item.height = 26;
			Item.uniqueStack = true;
			Item.rare = -11;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Pumpfish");
			//Tooltip.SetDefault("");
		}

		public override bool IsQuestFish()
		{
			return true;
		}

		public override bool IsAnglerQuestAvailable()
		{
			return NPC.downedBoss3;
		}

		public override void AnglerQuestChat(ref string description, ref string catchLocation)
		{
			description = "Jesus, what a terrible creation, this pumpkin fish. Imagine if all my fears come together in one conglomerate thing in form of vegetable and began to float mindlessly around the ocean! Catch her, and I will stop being afraid of it!";
			catchLocation = "Anywhere";
		}
	}
}
