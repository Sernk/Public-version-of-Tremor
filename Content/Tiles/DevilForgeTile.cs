using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TremorMod.Content.Tiles
{
	public class DevilForgeTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);
            TileObjectData.addTile(Type);
            AnimationFrameHeight = 36;
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
	        AddMapEntry(new Color(179, 146, 113), CreateMapEntryName());
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
            if(frameCounter > 6)
            {
                frameCounter = 0;
                frame++;
                frame %= 4;
            }
        }
    }
}