using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.Tiles
{
	public class CometiteOreTile : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;                   
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			DustType = 27;
			AddMapEntry(new Color(0, 191, 255), CreateMapEntryName());
			MineResist = 8f;
			MinPick = 225;
		}

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            if (Main.rand.Next(10) == 0)
            {
                // Создайте источник для события (разрушение плитки)
                IEntitySource source = new EntitySource_TileBreak(i, j);

                // Создаем предмет с использованием IEntitySource и координат в виде Vector2
                Item.NewItem(source, i * 16, j * 16, 16, 16, ModContent.ItemType<ChargedCrystal>());
            }
        }


        public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.5f;
			g = 0.0f;
			b = 0.7f;
		}
	}
}