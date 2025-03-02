using System.Linq;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using TremorMod;
using TremorMod.Content.NPCs.Bosses.NovaPillar.NPCs;

namespace TremorMod.Content.NPCs.Bosses.NovaPillar
{
    public class NovaHandler : ModSystem
    {
        public static int TowerX = -1;
        public static int TowerY = -1;
        public static bool TowerActive;
        public static int ShieldStrength;

        public static bool LunarApocalypseLastTick;
        private static bool NovaPillarSpawned = false; // Флаг для отслеживания появления NovaPillar

        public override void OnWorldLoad()
        {
            LunarApocalypseLastTick = NPC.LunarApocalypseIsUp;
            ShieldStrength = NPC.ShieldStrengthTowerMax;
            TowerX = -1;
            TowerY = -1;
            NovaPillarSpawned = false; // Сброс флага при загрузке мира
        }

        public override void SaveWorldData(TagCompound tag)
        {
            tag.Add("NovaActive", TowerActive);
            if (TowerX != -1)
            {
                tag.Add("NovaX", TowerX);
                tag.Add("NovaY", TowerY);
            }
            tag.Add("NovaPillarSpawned", NovaPillarSpawned); // Сохранение флага
        }

        public override void LoadWorldData(TagCompound tag)
        {
            TowerActive = tag.GetBool("NovaActive");
            if (tag.ContainsKey("NovaX"))
            {
                TowerX = tag.GetInt("NovaX");
                TowerY = tag.GetInt("NovaY");
                NPC.NewNPC(new EntitySource_WorldEvent(), TowerX, TowerY, ModContent.NPCType<NovaPillar>());
            }
            NovaPillarSpawned = tag.GetBool("NovaPillarSpawned"); // Загрузка флага
        }

        public override void PostUpdateWorld()
        {
            if (NPC.downedAncientCultist && !NovaPillarSpawned)
            {
                Mod.Logger.Info("Lunatic Cultist defeated. Spawning Nova Pillar...");
                SpawnNovaPillar(); // Появление NovaPillar
                NovaPillarSpawned = true; // Установка флага

                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.WorldData); // Синхронизация состояния мира
                }
            }

            LunarApocalypseLastTick = NPC.LunarApocalypseIsUp;
        }

        void SpawnNovaPillar()
        {
            Mod.Logger.Info("Attempting to spawn Nova Pillar");

            int spawnX = Main.spawnTileX; // Координата X точки спавна игрока
            int spawnY = Main.spawnTileY; // Координата Y точки спавна игрока
            int offset = 100; // Расстояние от спавна в блоках
            int x = spawnX + (Main.rand.Next(2) == 0 ? offset : -offset); // Случайное смещение на 100 блоков вправо или влево

            Vector2 spawnPos = new Vector2(x * 16, spawnY * 16);

            bool success = false;
            for (int attempts = 0; attempts < 30; attempts++)
            {
                int tryX = x + Main.rand.Next(-10, 11);
                for (int y = spawnY; y > 100; y--)
                {
                    if (!Collision.SolidTiles(tryX - 10, tryX + 10, y - 20, y + 15))
                    {
                        spawnPos = new Vector2(tryX * 16, y * 16);
                        success = true;
                        break;
                    }
                }
                if (success)
                {
                    break;
                }
            }

            if (success)
            {
                int whoAmI = NPC.NewNPC(new EntitySource_WorldEvent(), (int)spawnPos.X, (int)spawnPos.Y, ModContent.NPCType<NovaPillar>());
                if (whoAmI != 200) // Проверка успешного создания NPC
                {
                    Mod.Logger.Info($"Nova Pillar spawned at ({TowerX}, {TowerY})");
                    TowerX = (int)spawnPos.X;
                    TowerY = (int)spawnPos.Y;
                    ShieldStrength = NPC.ShieldStrengthTowerMax;
                    TowerActive = true;

                    if (Main.netMode == NetmodeID.Server && whoAmI < 200)
                    {
                        NetMessage.SendData(MessageID.SyncNPC, number: whoAmI);
                    }
                }
                else
                {
                    Mod.Logger.Error("Failed to spawn Nova Pillar."); // Логирование ошибки, если NPC не был создан
                }
            }
            else
            {
                Mod.Logger.Error("Failed to find suitable position for Nova Pillar."); // Логирование ошибки, если не удалось найти позицию
                if (Main.netMode != NetmodeID.Server)
                {
                    Main.NewText("Nova Pillar failed to spawn!", Color.Red); // Уведомление игроку
                }
            }
        }


        static readonly string[] NovaNPCs =
        {
            "NovaAlchemist",
            "Varki",
            "Youwarkee",
            "Deadling",
            "NovaFlier"
        };
    }
}