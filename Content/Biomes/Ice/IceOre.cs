using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Biomes.Ice
{
    public class IceOre : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = false;
            Main.tileMerge[Type][161] = true;
            Main.tileMerge[Type][162] = true;
            Main.tileMerge[Type][163] = true;
            Main.tileMerge[Type][164] = true;
            Main.tileMerge[Type][147] = true;
            //Main.tileMinPick[Type] = 200;
            MinPick = 95;
            HitSound = SoundID.Tink; // Use HitSound and assign an appropriate sound ID
            Main.tileLighted[Type] = true;
            AddMapEntry(new Color(117, 187, 253), CreateMapEntryName());
        }
    }
}