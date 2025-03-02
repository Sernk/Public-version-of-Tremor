using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.Enums;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.EvilCornItems;
using System.Collections.Generic;

namespace TremorMod.Content.Tiles
{
    public class CornTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileCut[Type] = true;
            Main.tileNoFail[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);
            TileObjectData.newTile.AnchorValidTiles = new[]
            {
                2
            };
            TileObjectData.addTile(Type);
        }
        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            var source = new Terraria.DataStructures.EntitySource_TileBreak(i, j);

            bool dropCorn = Main.rand.NextBool(1);
            bool dropLunarRoot = Main.rand.NextBool(99999);

            if (!dropCorn && !dropLunarRoot)
            {
                dropLunarRoot = true;
            }

            if (dropCorn)
            {
                Item.NewItem(source, i * 16, j * 16, 16, 16, ModContent.ItemType<Corn>(), Main.rand.Next(1, 3));
            }

            if (dropLunarRoot)
            {
                Item.NewItem(source, i * 16, j * 16, 16, 16, ModContent.ItemType<LunarRoot>(), Main.rand.Next(1, 2));
            }
        }

        public override void RandomUpdate(int i, int j)
        {
            if (Main.tile[i, j].TileFrameX == 0)
            {
                Main.tile[i, j].TileFrameX += 18;
            }
            else if (Main.tile[i, j].TileFrameX == 18)
            {
                Main.tile[i, j].TileFrameX += 18;
            }
        }
    }
}