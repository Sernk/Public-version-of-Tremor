using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Fish
{
	public class SunflowerFish : ModItem
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
			// DisplayName.SetDefault("Sunflower Fish");
			// Tooltip.SetDefault("");
		}

		public override bool IsQuestFish()
		{
			return true;
		}

		public override bool IsAnglerQuestAvailable()
		{
			return NPC.downedBoss1;
		}

		public override void AnglerQuestChat(ref string description, ref string catchLocation)
		{
			description = "I can tell you that it's a quite a rare creature. They say that it can cure all diseases and convert sunlight into happiness... Why you're still here?! Catch her! Now!";
			catchLocation = "Anywhere";
		}
	}
}
