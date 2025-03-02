using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Tiles
{
	public class LunarRootTile : ModTile
	{
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.addTile(Type);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16 };
            DustType = 7;
            //TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.Table, TileObjectData.newTile.Width, 0);
            AddMapEntry(new Color(200, 200, 200), CreateMapEntryName());
            MineResist = 1f;
            MinPick = 0;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            var source = new Terraria.DataStructures.EntitySource_TileBreak(i, j);

            bool dropNightCore = Main.rand.NextBool(2); 
            bool dropLunarRoot = Main.rand.NextBool(4); 

            if (!dropNightCore && !dropLunarRoot)
            {
                dropLunarRoot = true;
            }

            if (dropNightCore)
            {
                Item.NewItem(source, i * 16, j * 16, 16, 16, ModContent.ItemType<NightCore>(), Main.rand.Next(1, 3));
            }

            if (dropLunarRoot)
            {
                Item.NewItem(source, i * 16, j * 16, 16, 16, ModContent.ItemType<LunarRoot>(), Main.rand.Next(1, 2));
            }
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