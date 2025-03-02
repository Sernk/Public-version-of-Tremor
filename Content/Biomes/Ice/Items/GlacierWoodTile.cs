using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Biomes.Ice;

namespace TremorMod.Content.Biomes.Ice.Items
{
	public class GlacierWoodTile : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			DustType = 80;
			AddMapEntry(new Color(0, 191, 255), CreateMapEntryName());
			Main.tileMerge[Type][ModContent.TileType<IceBlock>()] = true;
			Main.tileMerge[Type][TileID.IceBlock] = true; // normal ice
			Main.tileMerge[Type][TileID.BreakableIce] = true; // thin ice
			Main.tileMerge[Type][TileID.CorruptIce] = true; // purple ice
			Main.tileMerge[Type][TileID.HallowedIce] = true; // pink ice
			Main.tileMerge[Type][TileID.SnowBlock] = true; // snow
		}
	}
}
