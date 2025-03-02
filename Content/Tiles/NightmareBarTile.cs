using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TremorMod.Content.Dusts;

namespace TremorMod.Content.Tiles
{
	public class NightmareBarTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.CoordinateHeights = new[]{16};
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);
            DustType = ModContent.DustType<Dusts.NightmareFlame>();
            AddMapEntry(new Color(90, 0, 150), CreateMapEntryName());
            Main.tileShine[Type] = 1100;
            Main.tileSolid[Type] = true;
        }        
    }
}
