using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Fish
{
	public class CoalFish : ModItem
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
			//DisplayName.SetDefault("Coal Fish");
			//Tooltip.SetDefault("");
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
			description = "Oh, this wonderful underwater world! How much it hides.. There is a fish, black and dirty as coal.  Catch it and try not to drabble your hands!";
			catchLocation = "Anywhere";
		}
	}
}
