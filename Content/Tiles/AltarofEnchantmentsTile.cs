using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TremorMod.Content.Tiles
{
    public class AltarofEnchantmentsTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.addTile(Type);
            DustType = 7;
            //ModTranslation name = CreateMapEntryName();
            //name.SetDefault("Altar of Enchantments");				
            AddMapEntry(new Color(120, 85, 60), CreateMapEntryName());
        }

        /*public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            if (frameX == 0)
            {
                Item.NewItem(WorldGen.GetItemSource_FromTileBreak(i, j), i * 16, j * 16, 48, 48, ModContent.ItemType<AltarofEnchantments>());
            }
        }*/
    }
}