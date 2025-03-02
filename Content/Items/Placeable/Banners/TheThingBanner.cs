using TremorMod.Content.Tiles.Banners;
using Terraria.Enums; 
using Terraria.ModLoader;
using Terraria;
using Terraria.ObjectData;

namespace TremorMod.Content.Items.Placeable.Banners
{
    public class TheThingBanner : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<EnemyBanner>(), (int)EnemyBanner.StyleID.TheThing);
            Item.width = 10;
            Item.height = 24;
            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(silver: 10));
        }

        public override void SetStaticDefaults()
        {
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.newTile.StyleHorizontal = true;
        }
    }
}