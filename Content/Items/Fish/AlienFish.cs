using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Fish
{
	public class AlienFish : ModItem
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
			// DisplayName.SetDefault("Alien Fish");
			// Tooltip.SetDefault("");
		}

		public override bool IsQuestFish()
		{
			return true;
		}

		public override bool IsAnglerQuestAvailable()
		{
			return NPC.downedMechBossAny;
		}

		public override void AnglerQuestChat(ref string description, ref string catchLocation)
		{
			description = "If a fish can't breathe under water without a suit, then it must be... an alien fish! Catch for me this valuable specimen!";
			catchLocation = "Anywhere";
		}
	}
}
