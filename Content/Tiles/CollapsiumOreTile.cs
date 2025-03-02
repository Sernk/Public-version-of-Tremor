using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace TremorMod.Content.Tiles
{
    public class CollapsiumOreTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            DustType = 62;
            HitSound = SoundID.Tink;
            //PlaceSound = SoundID.Item2;
            MinPick = 250;
            AddMapEntry(new Color(255, 20, 147), CreateMapEntryName());
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.9f;
            g = 0.1f;
            b = 0.5f;
        }
    }
}