using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class UntreatedFlesh : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 22;
			Item.maxStack = 99;
			Item.value = 80;
			Item.rare = 1;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Untreated Flesh");
			Tooltip.SetDefault("");
		}*/
	}
}
