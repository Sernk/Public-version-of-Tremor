using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class HuskofDusk : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 22;
			Item.maxStack = 999;
			Item.value = 200;
			Item.rare = 11;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Husk of Dusk");
			Tooltip.SetDefault("");
		}*/

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.Purple;
		}
	}
}
