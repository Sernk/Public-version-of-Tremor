using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Tiles
{
	public class AncientBannerTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.addTile(Type);
            DustType = 7;
	        AddMapEntry(new Color(225, 184, 115), CreateMapEntryName());
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if(closer)
            {
                Player player = Main.player[Main.myPlayer];
                int style = Main.tile[i, j].TileFrameX / 15;
                //string type;
                player.AddBuff(ModContent.BuffType<AncientBannerBuff>(), 60, true);
            }
        }
    }
}