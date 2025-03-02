using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Biomes.Ice.Tree;

namespace TremorMod.Content.Biomes.Ice.Tree
{
    public class VeryVery : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<VeryVeryIce>();
        }

        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Everfrost Block");
			Tooltip.SetDefault("");
		}*/
    }
}
