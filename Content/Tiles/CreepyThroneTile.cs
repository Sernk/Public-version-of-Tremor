using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ObjectData;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Tiles
{
	public class CreepyThroneTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
            TileObjectData.newTile.CoordinateHeights = new[]{16, 16, 16, 16};
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.addTile(Type);
            DustType = 7;
	        AddMapEntry(new Color(120, 85, 60), CreateMapEntryName());
        }
    }
}