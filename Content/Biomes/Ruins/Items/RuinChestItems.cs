using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Biomes.Ruins.Tiles;

namespace TremorMod.Content.Biomes.Ruins.Items
{
    public class RuinChestItems : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<RuinChest>());
            Item.width = 26;
            Item.height = 22;
            Item.value = 500;
        }
        
    }
}