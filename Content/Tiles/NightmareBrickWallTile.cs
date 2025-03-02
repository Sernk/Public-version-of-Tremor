using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Tiles
{
	public class NightmareBrickWallTile : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
	        AddMapEntry(new Color(90, 12, 157), CreateMapEntryName());
        }
    }
}