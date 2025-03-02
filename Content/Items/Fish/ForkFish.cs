using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Fish
{
	public class ForkFish : ModItem
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
			//DisplayName.SetDefault("Fork Fish");
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
			description = "I broke all my forks! What am I going to do without them? Catch this fish, so I could... eat fish!";
			catchLocation = "Anywhere";
		}
	}
}
