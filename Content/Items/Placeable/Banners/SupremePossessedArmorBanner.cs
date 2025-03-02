using TremorMod.Content.Tiles.Banners;
using Terraria.Enums; 
using Terraria.ModLoader;
using Terraria;
using Terraria.ObjectData;

namespace TremorMod.Content.Items.Placeable.Banners
{
    public class SupremePossessedArmorBanner : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<EnemyBanner>(), (int)EnemyBanner.StyleID.SupremePossessedArmor);
            Item.width = 10;
            Item.height = 24;
            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(silver: 10));
        }
    }
}