using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.BossSumonItems
{
	public class MartianCommunicator : ModItem
	{
		const int XOffset = 0;
		const int YOffset = -200;

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 30;
			Item.maxStack = 20;
			Item.value = 100;
			Item.rare = 1;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.useStyle = 4;
			Item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Martian Communicator");
			//Tooltip.SetDefault("Starts the Martian Madness");
		}

		public override bool CanUseItem(Player player)
		{
			return Main.hardMode && NPC.downedGolemBoss;
		}

		public override bool? UseItem(Player player)
		{
			Main.StartInvasion(4);
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MartianConduitPlating, 25);
			recipe.AddIngredient(ItemID.SoulofMight, 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(ItemID.Wire, 40);
			//recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.Register();
		}
	}
}
