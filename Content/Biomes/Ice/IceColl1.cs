using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TremorMod.Content.Dusts;

namespace TremorMod.Content.Biomes.Ice
{
    public class IceColl1 : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileCut[Type] = true;
            Main.tileNoFail[Type] = true;
            Main.tileWaterDeath[Type] = false;
            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);
            DustType = ModContent.DustType<IceDust>();
            HitSound = SoundID.Item21;
            TileObjectData.newTile.WaterDeath = false;
            TileObjectData.addTile(Type);
        }
        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }

        public override void RandomUpdate(int i, int j)
        {
            var tile = Framing.GetTileSafely(i, j); // Безопасный доступ к Tile.
            if (tile.TileFrameX == 0)
            {
                tile.TileFrameX += 18;
            }
            else if (tile.TileFrameX == 18)
            {
                tile.TileFrameX += 18;
            }
        }
    }
}