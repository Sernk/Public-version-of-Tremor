using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Fish
{
	public class GlassFish : ModItem
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
			//DisplayName.SetDefault("Glass Fish");
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
			description = "To tell the truth, this fish is quite dangerous because you can cut yourself with it! Although what a difference! Catch her and just try to break her! ";
			catchLocation = "Anywhere";
		}
	}
}
