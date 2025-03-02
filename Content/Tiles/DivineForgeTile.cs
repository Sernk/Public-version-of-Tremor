using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TremorMod.Content.Tiles
{
	public class DivineForgeTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            //TileObjectData.newTile.CoordinateHeights = new int[]{16};
            TileObjectData.addTile(Type);
            AnimationFrameHeight = 54;
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
	        AddMapEntry(new Color(255, 20, 147), CreateMapEntryName());	
            AdjTiles = new[]{412,133,16,17,134};
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.9f;
            g = 0.1f;
            b = 0.5f;
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
            if(frameCounter > 8)
            {
                frameCounter = 0;
                frame++;
                frame %= 4;
            }
        }
    }
}