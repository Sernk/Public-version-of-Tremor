using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.NPCs;
using TremorMod.Content.NPCs.Bosses.TikiTotem;
using TremorMod.Content.Items;
using TremorMod.Content.Tiles;
using Terraria.Localization;
using Terraria.ModLoader.IO;
using TremorMod.Content.NPCs.Bosses.SpaceWhale;

namespace TremorMod.Utilities
{
    public partial class TremorSpawnEnemys : ModSystem
    {
        public static bool downedTikiTotem = false;
        public static bool downedTrinity = false;
        public static bool downedAlchemaster = false;
        public static bool downedRukh = false;
        public static bool downedSpaceWhale = false;
        public static bool downedMotherboard = false;
        public static bool spawnedAngeliteLast = false;

        public override void OnWorldLoad()
        {
            downedTikiTotem = false; // Изначально босс не убит
            downedTrinity = false;
            downedRukh = false;
            downedSpaceWhale = false;
            spawnedAngeliteLast = false;
            downedAlchemaster = false;
            downedMotherboard = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            tag["downedTikiTotem"] = downedTikiTotem; // Сохраняем состояние в мире
            tag["downedTrinity"] = downedTrinity;
            tag["spawnedAngeliteLast"] = spawnedAngeliteLast;
            tag["downedAlchemaster"] = downedAlchemaster;
            tag["downedMotherboard"] = downedMotherboard;
            tag["downedRukh"] = downedRukh;
            tag["downedSpaceWhale"] = downedSpaceWhale;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            downedTikiTotem = tag.GetBool("downedTikiTotem"); // Загружаем состояние из мира
            downedTrinity = tag.GetBool("downedTrinity");
            spawnedAngeliteLast = tag.GetBool("spawnedAngeliteLast");
            downedAlchemaster = tag.GetBool("downedAlchemaster");
            downedMotherboard = tag.GetBool("downedMotherboard");
            downedRukh = tag.GetBool("downedRukh");
            downedSpaceWhale = tag.GetBool("downedSpaceWhale");
        }
    }
}