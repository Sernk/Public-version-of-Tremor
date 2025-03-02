using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Items.Materials
{
	public class AntlionShell : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 24;
			Item.maxStack = 99;
			Item.value = 100;
			Item.rare = 2;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Antlion Shell");
			Tooltip.SetDefault("");
		}*/

	}
}
