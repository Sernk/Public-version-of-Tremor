using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TremorMod.Content.Tiles
{
	public class RedBrickChimneyTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.addTile(Type);
            AnimationFrameHeight = 56;
            TileObjectData.newTile.CoordinateHeights = new[]{ 16, 16, 18};
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
	        AddMapEntry(new Color(117, 117, 117), CreateMapEntryName());
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
            if(frameCounter > 5)
            {
                frameCounter = 0;
                frame++;
                frame %= 6;
            }
        }
    }
}