using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Tiles
{
	public class GloomstoneTile : ModTile
	{
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true; // Плитка является твердой.
            Main.tileMergeDirt[Type] = true; // Сливается с грязью.
            Main.tileBlockLight[Type] = true; // Блокирует свет.
            Main.tileLighted[Type] = true; // Освещается.
            //ItemDrop = ModContent.ItemType<GloomstoneItem>(); // Выпадающий предмет.
            HitSound = SoundID.Tink; // Звук при разрушении.
            AddMapEntry(new Color(36, 118, 174));
        }

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}
