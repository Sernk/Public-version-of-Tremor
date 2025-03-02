using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items;
using TremorMod.Content.Tiles;

namespace TremorMod.Content.Items.CraftingStations
{
    public class GreatAnvil : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 14;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 150;
            Item.createTile = ModContent.TileType<GreatAnvilTile>();
        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Great Anvil");
            //Tooltip.SetDefault("Allows to produce heavy weapons");
        }
    }
}