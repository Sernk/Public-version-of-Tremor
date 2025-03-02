using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TremorMod.Content.Items.Placeable;

namespace TremorMod.Content.Tiles
{
    public class SandstoneBathtubTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2); // Ётот стиль автоматически учитывает направление
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16 };
            TileObjectData.addTile(Type);

            // ƒобавление в массивы дл€ функционала кровати
            TileID.Sets.CanBeSleptIn[Type] = true; // ”казывает, что плитка может быть использована как кровать
            TileID.Sets.IsValidSpawnPoint[Type] = true; // ѕозвол€ет установить точку возрождени€

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable); // ƒобавл€ет, чтобы плитка считалась как стол (если нужно)
            AddMapEntry(new Color(233, 211, 123), CreateMapEntryName());
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;

            // ”казываем, что игрок взаимодействует с предметом
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ModContent.ItemType<SandstoneBathtub>(); // ”казываем иконку дл€ отображени€
        }

        // ѕереопределите метод дл€ обработки взаимодействи€ с кроватью
      
    }
}
