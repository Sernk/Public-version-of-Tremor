using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class EarthFragment : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 24;
			Item.maxStack = 99;
			Item.value = 100;
			Item.rare = 1;
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            //ItemID.Sets.ItemIconPulse[Item.type] = true;
        }

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Earth Fragment");
			//Tooltip.SetDefault("");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(8, 4));
		}

	}
}
