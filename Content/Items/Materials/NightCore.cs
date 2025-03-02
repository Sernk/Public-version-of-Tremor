using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class NightCore : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 22;
			Item.maxStack = 999;
			Item.value = 100;
			Item.rare = 10;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Night Core");
			Tooltip.SetDefault("");
		}*/

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.Purple;
		}
	}
}
