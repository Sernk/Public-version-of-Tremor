using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Biomes.Ice;
using TremorMod.Content.Dusts;

namespace TremorMod.Content.Biomes.Ice.Dungeon
{
	public class DungeonBlock : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileMerge[Type][ModContent.TileType<IceBlock>()] = true;
			Main.tileMerge[Type][ModContent.TileType<Ice.Tree.VeryVeryIce>()] = true;
			Main.tileMerge[Type][147] = true;
			DustType = ModContent.DustType<IceDust>();
			AddMapEntry(new Color(70, 156, 213), CreateMapEntryName());
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.5f;
			g = 0.5f;
			b = 0.5f;
		}
	}
}