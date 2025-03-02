using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TremorMod.Content;
using TremorMod.Content.Items.Placeable;

namespace TremorMod.Content.Tiles
{
	public class NovaMonolithTile : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(1, 2);
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 18 };
			TileObjectData.addTile(Type);
			AddMapEntry(new Color(75, 139, 166), CreateMapEntryName());
			DustType = 1;
			AnimationFrameHeight = 56;
			//disableSmartCursor = true;
			AdjTiles = new int[] { TileID.LunarMonolith };
		}

		public override void NearbyEffects(int i, int j, bool closer)
		{
			if (Main.tile[i, j].TileFrameY >= 56)
			{
				TremorPlayer modPlayer = Main.LocalPlayer.GetModPlayer<TremorPlayer>();
				modPlayer.NovaMonolith = true;
			}
		}

		public override void AnimateTile(ref int frame, ref int frameCounter)
		{
			frame = Main.tileFrame[TileID.LunarMonolith];
			frameCounter = Main.tileFrameCounter[TileID.LunarMonolith];
		}

        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Texture2D texture;

            // Modify or remove custom methods if needed, adjust drawing logic accordingly.
            texture = TextureAssets.Tile[Type].Value;  // Default texture for the tile

            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }

            int height = tile.TileFrameY == 36 ? 18 : 16;
            int animate = 0;
            if (tile.TileFrameY >= 56)
            {
                animate = Main.tileFrame[Type] * AnimationFrameHeight;
            }

            // Draw the default tile texture
            Main.spriteBatch.Draw(texture,
                new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
                new Rectangle(tile.TileFrameX, tile.TileFrameY + animate, 16, height),
                Lighting.GetColor(i, j), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);

            // Draw the glow mask with the proper ModContent.GetTexture
            Main.spriteBatch.Draw(ModContent.Request<Texture2D>("TremorMod/Content/Tiles/NovaMonolithTile_Glowmask").Value,
                 new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
                new Rectangle(tile.TileFrameX, tile.TileFrameY + animate, 16, height),
                Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

            return false;
        }


        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;

            if (player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance))
            { // Avoid being able to trigger it from long range
                player.GamepadEnableGrappleCooldown();
                player.sitting.SitDown(player, i, j);
            }

            return true;
        }

        public override void MouseOver(int i, int j)
		{
			Player player = Main.LocalPlayer;
			player.noThrow = 2;
			player.cursorItemIconEnabled = true;
			player.cursorItemIconID = ModContent.ItemType<NovaMonolith>();
		}

        public override void HitWire(int i, int j)
        {
            int x = i - (Main.tile[i, j].TileFrameX / 18) % 2;
            int y = j - (Main.tile[i, j].TileFrameY / 18) % 3;

            for (int l = x; l < x + 2; l++)
            {
                for (int m = y; m < y + 3; m++)
                {
                    Tile tile = Main.tile[l, m];
                    if (tile == null || !tile.HasTile || tile.TileType != Type)
                        continue;

                    tile.TileFrameY = (short)((tile.TileFrameY < 56) ? (tile.TileFrameY + 56) : (tile.TileFrameY - 56));
                }
            }

            if (Wiring.running)
            {
                Wiring.SkipWire(x, y);
                Wiring.SkipWire(x, y + 1);
                Wiring.SkipWire(x, y + 2);
                Wiring.SkipWire(x + 1, y);
                Wiring.SkipWire(x + 1, y + 1);
                Wiring.SkipWire(x + 1, y + 2);
            }

            NetMessage.SendTileSquare(-1, x, y + 1, 3);
        }


    }
}