using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Tiles.GloomstoneTiles
{
	public class GloomstoneBrickWallTile : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
	        AddMapEntry(new Color(10, 63, 98), CreateMapEntryName());
        }
    }
}