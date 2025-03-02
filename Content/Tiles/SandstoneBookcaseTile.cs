using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TremorMod.Content.Tiles
{
	public class SandstoneBookcaseTile : ModTile
	{
        public override void SetStaticDefaults()
        {
            // Настройки плитки
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = true;

            // Конфигурация TileObjectData
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4); // Размер 3x4
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 16 }; // Высота каждой строки в пикселях
            TileObjectData.addTile(Type);

            // Указание, что эта плитка аналогична книжному шкафу
            AdjTiles = new int[] { TileID.Bookcases };

            // Карта
            AddMapEntry(new Color(233, 211, 123), CreateMapEntryName());
        }
    }
}