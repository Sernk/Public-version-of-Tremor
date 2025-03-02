using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using TremorMod.Content.Biomes.Ice.Tree;
using TremorMod.Content.Biomes.Ice.Dungeon;

namespace TremorMod.Content.Biomes.Ice
{
	public class IceBlock : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = false;
			Main.tileLighted[Type] = false;
			DustType = 80;
            HitSound = SoundID.Item21;
            AddMapEntry(new Color(84, 166, 229), CreateMapEntryName());
			Main.tileMerge[Type][ModContent.TileType<IceOre>()] = true;
			Main.tileMerge[Type][ModContent.TileType<VeryVeryIce>()] = true;
			Main.tileMerge[Type][ModContent.TileType<DungeonBlock>()] = true;
			Main.tileMerge[Type][TileID.IceBlock] = true;
			Main.tileMerge[Type][TileID.BreakableIce] = true;
			Main.tileMerge[Type][TileID.CorruptIce] = true;
			Main.tileMerge[Type][TileID.HallowedIce] = true;
			Main.tileMerge[Type][TileID.SnowBlock] = true;
		}

		public bool CanGrow(int i, int j)
		{
			bool flag = false;
			for (int x = 0; x < 3; x++)
				for (int y = 0; y < 3; y++)
				{
					if (!Main.tile[i - 1 + x, j - 1 + y].HasTile)
						flag = true;
				}
			return flag;
		}

		/*public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {
                Player player = Main.player[Main.myPlayer];
                int style = Main.tile[i, j].frameX / 15;
                string type;
                Main.player[Main.myPlayer].GetModPlayer<TremorPlayer>(mod).ZoneIce = true;
                TremorPlayer modPlayer = Main.player[Main.myPlayer].GetModPlayer<TremorPlayer>(mod);
                modPlayer.ZoneIce = true;
            } 
        } */

		/*public override void RandomUpdate(int i, int j)
        {
            if (Main.tile[i - 1, j].type > 0 && CanGrow(i - 1, j))
            {
                Main.tile[i - 1, j].type = (ushort)mod.TileType("IceBlock");
            }
            if (Main.tile[i + 1, j].type > 0 && CanGrow(i + 1, j))
            {
                Main.tile[i + 1, j].type = (ushort)mod.TileType("IceBlock");
            }
            if (Main.tile[i, j - 1].type > 0 && CanGrow(i, j - 1))
            {
                Main.tile[i, j - 1].type = (ushort)mod.TileType("IceBlock");
            }
            if (Main.tile[i, j + 1].type > 0 && CanGrow(i, j + 1))
            {
                Main.tile[i, j + 1].type = (ushort)mod.TileType("IceBlock");
            }
        } */
	}
}