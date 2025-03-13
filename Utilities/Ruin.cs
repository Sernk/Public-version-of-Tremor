using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using TremorMod;
using Terraria.GameContent.Generation;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using TremorMod.Content.Biomes.Ice;
using TremorMod.Content.Biomes.Ice.Items.Furniture;
using TremorMod.Content.Biomes.Ruins.Tiles;
using StructureHelper.API;
using static StructureHelper.API.Generator;

namespace TremorMod.Utilities
{
    public class Ruin : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (ShiniesIndex == -1)
            {
                // Shinies pass removed by some other mod.
                return;
            }
            tasks.Insert(ShiniesIndex + 1, new PassLegacy("Generating dungeon", (progress, configuration) =>
            {
                progress.Message = "Generating ruins...";

                CreateRuin();
            }));
        }

        private void CreateRuin()
        {
            int worldWidth = Main.maxTilesX;
            int worldHeight = Main.maxTilesY;
            int ruinX = worldWidth / 2; // Öåíòð ìèðà ïî X
            int ruinY = worldHeight - 500; // 500 áëîêîâ îò íèæíåé ãðàíèöû

            string structurePath = "Structures/Ruin";
            
            // Генерация структуры с использованием нового API
            StructureHelper.API.Generator.GenerateStructure(structurePath, new Point16(ruinX, ruinY), TremorMod.Instance);
        }
    }
}
