using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class AdventurerSpark : ModItem
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Adventurer Spark");
			//Tooltip.SetDefault("Can be enchanted only once!");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 22;
			Item.rare = 1;
			Item.value = Item.buyPrice(silver: 1);
		}
	}
}
