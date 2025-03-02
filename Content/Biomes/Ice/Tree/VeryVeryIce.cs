using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Biomes.Ice;
using TremorMod.Content.Biomes.Ice.Items;
using Terraria.GameContent.Generation;
using Terraria.DataStructures;

namespace TremorMod.Content.Biomes.Ice.Tree
{
    public class VeryVeryIce : ModTile
    {
        public override void SetStaticDefaults()
        {
            // Set the tile properties
            Main.tileSolid[Type] = true;
            Main.tileMerge[Type][Mod.Find<ModTile>("IceBlock").Type] = true;
            Main.tileMerge[Type][161] = true;
            Main.tileMerge[Type][162] = true;
            Main.tileMerge[Type][163] = true;
            Main.tileMerge[Type][164] = true;
            Main.tileMerge[Type][147] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = false;
            DustType = 80;
            HitSound = SoundID.Dig;
            Main.tileLighted[Type] = true;

            // Add map entry
            AddMapEntry(new Color(104, 155, 195), CreateMapEntryName());

            // Set tree growth
            //ModTree = new TremorTree(); // Assuming TremorTree is a valid ModTree
        }

        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            Tile tile = Main.tile[i, j];
            int height = tile.TileFrameY == 36 ? 18 : 16;
            int animate = 0;
            if (tile.TileFrameY >= 56)
            {
                animate = Main.tileFrame[Type] * AnimationFrameHeight;
            }
            Texture2D texture = TextureAssets.Tile[Type].Value;
            Main.spriteBatch.Draw(texture, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY + animate, 16, height), Lighting.GetColor(i, j), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
            return false;
        }

        public override void RandomUpdate(int i, int j)
        {
            if (Main.tile[i - 1, j].TileType == TileID.SnowBlock && CanGrow(i - 1, j))
            {
                Main.tile[i - 1, j].TileType = (ushort)Mod.Find<ModTile>("IceBlock").Type;
            }
            if (Main.tile[i + 1, j].TileType == TileID.SnowBlock && CanGrow(i + 1, j))
            {
                Main.tile[i + 1, j].TileType = (ushort)Mod.Find<ModTile>("IceBlock").Type;
            }
            if (Main.tile[i, j - 1].TileType == TileID.SnowBlock && CanGrow(i, j - 1))
            {
                Main.tile[i, j - 1].TileType = (ushort)Mod.Find<ModTile>("IceBlock").Type;
            }
            if (Main.tile[i, j + 1].TileType == TileID.SnowBlock && CanGrow(i, j + 1))
            {
                Main.tile[i, j + 1].TileType = (ushort)Mod.Find<ModTile>("IceBlock").Type;
            }
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

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            // Drop the tree wood
            int woodCount = Main.rand.Next(10, 20);
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ModContent.ItemType<GlacierWood>(), woodCount);
        }
    }
}