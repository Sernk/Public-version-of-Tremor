using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using System.Collections.Generic;  // Добавляем эту строку для работы с List<T>

namespace TremorMod.Content.Tiles
{
    public class AngeliteOreTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.Ore[Type] = true;
            // Устанавливаем базовые свойства плитки
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;

            // Задаём тип пыли, которая будет генерироваться при разрушении плитки
            DustType = 57;

            // Задаём звук для разрушения плитки
            HitSound = SoundID.Tink;  // Установим звук разрушения

            // Задаём сопротивление разрушению и минимальную кирку
            MineResist = 15f;          // Уровень сопротивления разрушению плитки
            MinPick = 250;             // Минимальный уровень кирки для разрушения плитки

            // Добавляем плитку на карту с указанным цветом
            AddMapEntry(new Color(0, 191, 255), CreateMapEntryName());
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0f;
            g = 0.3f;
            b = 0.9f;
        }
    }
}
