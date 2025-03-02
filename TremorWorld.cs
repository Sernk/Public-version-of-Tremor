using System;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using System.Collections.Generic;
using Terraria.IO;
using Terraria.WorldBuilding;
using System.Reflection;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using ReLogic.Utilities;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.Localization;
using Filters = Terraria.Graphics.Effects.Filters;
using TremorMod.Content.Items;
using TremorMod.Content.Biomes.Ice;
using TremorMod.Content.Biomes.Ice.Items;
using TremorMod;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Tiles;
using TremorMod.Content.Biomes.Ruins.Tiles;
using TremorMod.Content.Biomes.Ruins.Items;
using TremorMod.Content.Biomes.Ice.Items.Furniture;
using TremorMod.Content.Biomes.Ice.Dungeon;
using ArgiteBar = TremorMod.Content.Items.Materials.OreAndBar.ArgiteBar;
using StructureHelper;

namespace TremorMod
{
    public class TremorWorld : ModSystem
    {
        public static bool HasGeneratedLunarRootTile;
        public static bool HasGeneratedCometiteOre = false;
        public enum Boss
        {
            EvilCorn,
            Rukh,
            SpaceWhale,
            Trinity,
            Tremode,
            TikiTotem,
            StormJellyfish,
            CyberKing,
            HeaterofWorlds,
            FrostKing,
            DarkEmperor,
            PixieQueen,
            Alchemaster,
            Brutallisk,
            ParadoxTitan,
            CogLord,
            //WallofShadow, // ?
            Motherboard,
            FungusBeetle,
            AncientDragon,
            Andas,
            NovaPillar,
            WallOfShadow
        }

        private Boss FindBossMatch(string boss)
            => (Boss)Enum.Parse(typeof(Boss), boss, true);

        public static Dictionary<Boss, bool> downedBoss;

        public static void Init()
        {
            if (downedBoss == null)
            {
                downedBoss = new Dictionary<Boss, bool>();
            }
            foreach (Boss boss in Enum.GetValues(typeof(Boss)).Cast<Boss>())
            {
                downedBoss[boss] = false;
            }
        }

        public override void OnWorldLoad()/* tModPorter Suggestion: Also override OnWorldUnload, and mirror your worldgen-sensitive data initialization in PreWorldGen */
        {
            Init();
        }

        public override void SaveWorldData(TagCompound tag)
        {
            var downed = new List<string>();

            if (downedBoss != null) // Ensure downedBoss is not null
            {
                foreach (var pair in downedBoss.Where(kvp => kvp.Value))
                {
                    string boss = pair.Key.ToString();
                    downed.Add(char.ToLowerInvariant(boss[0]) + boss.Substring(1));
                }
            }

            tag["downed"] = downed;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            foreach (string boss in downed)
            {
                /*try
				{
					downedBoss[FindBossMatch(boss)] = true;
				}
				catch (Exception e)
				{

				}*/
            }
        }

        public void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            if (loadVersion == 0)
            {
                BitsByte flags = reader.ReadByte();

                foreach (Boss boss in Enum.GetValues(typeof(Boss)).Cast<Boss>())
                {
                    downedBoss[boss] = flags[(int)boss];
                }
            }
            else
            {
                //ErrorLogger.Log("Tremor: Unknown loadVersion: " + loadVersion);
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            int bossCount = Enum.GetNames(typeof(Boss)).Length;
            int allocations = (int)Math.Ceiling(bossCount / 8f);

            if (allocations > 0)
            {
                writer.Write(bossCount);
                writer.Write(allocations);

                BitsByte[] bits = new BitsByte[allocations];

                for (int i = 0; i < bossCount; i++)
                {
                    bits[i / 8][i % 8] = downedBoss[(Boss)i];
                }

                foreach (BitsByte b in bits)
                {
                    writer.Write(b);
                }
            }
        }

        //NetReceive is called before Initialize when joining a server
        public override void NetReceive(BinaryReader reader)
        {
            Init();

            int bossCount = reader.ReadInt32();
            int allocations = reader.ReadInt32();

            if (allocations > 0)
            {
                BitsByte[] bits = new BitsByte[allocations];

                for (int i = 0; i < allocations; i++)
                {
                    bits[i] = reader.ReadByte();
                }

                for (int i = 0; i < bossCount; i++)
                {
                    downedBoss[(Boss)i] = bits[i / 8][i % 8];
                }
            }
        }

        public static int CometTiles;
        public static int GraniteTiles;
        public static int IceTiles;
        public static int RuinsTiles;

        private void GenArgite(GenerationProgress progress)
        {
            progress.Message = "Generating argite";

            for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
            {
                int i2 = WorldGen.genRand.Next(0, Main.maxTilesX);
                int j2 = WorldGen.genRand.Next((int)(Main.maxTilesY * .3f), (int)(Main.maxTilesY * .45f));
                WorldGen.OreRunner(i2, j2, WorldGen.genRand.Next(3, 4), WorldGen.genRand.Next(3, 8), (ushort)Mod.Find<ModTile>("ArgiteOre").Type);
            }
        }
        private int GetSizeByWorld(int maxTilesX, int maxTilesY)
        {
            // Пример расчета размера биома в зависимости от размера мира
            if (maxTilesX <= 4200) // Малый мир
                return 50;
            if (maxTilesX <= 6400) // Средний мир
                return 100;
            return 150; // Большой мир
        }

        // todo:
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int shiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (shiniesIndex == -1)
            {
                return;
            }

            tasks.Insert(shiniesIndex + 4, new PassLegacy("Generating argite", new WorldGenLegacyMethod(GenArgite)));
            tasks.Insert(shiniesIndex + 8, new PassLegacy("Mod Biomes", new WorldGenLegacyMethod(GenGlacier)));
            tasks.Insert(shiniesIndex + 10, new PassLegacy("Placing dungeon chest", new WorldGenLegacyMethod(GenChests)));
        }
        private void GenArgite(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating argite";

            for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
            {
                int i2 = WorldGen.genRand.Next(0, Main.maxTilesX);
                int j2 = WorldGen.genRand.Next((int)(Main.maxTilesY * .3f), (int)(Main.maxTilesY * .45f));
                WorldGen.OreRunner(i2, j2, WorldGen.genRand.Next(3, 4), WorldGen.genRand.Next(3, 8), (ushort)Mod.Find<ModTile>("ArgiteOreTile").Type);
            }
        }

        private void GenGlacier(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating glacier...";
            int size = GetSizeByWorld(Main.maxTilesX, Main.maxTilesY);

            for (int x = 0; x < Main.maxTilesX; x++)
            {
                for (int y = (int)Main.worldSurface; y < Main.maxTilesY; y++)
                {
                    // Проверяем, является ли тайл снегом
                    if (Main.tile[x, y].TileType == TileID.SnowBlock)
                    {
                        GenerateIceBiome(x, y, size);
                        break;
                    }
                }
            }
        }

        private void GenChests(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Placing dungeon chest";

            for (int c = 0; c < 2; c++)
            {
                WorldGen.PlaceChest(
                    Main.dungeonX + WorldGen.genRand.Next(100, 1000),
                    Main.dungeonY + WorldGen.genRand.Next(100, 1000),
                    (ushort)Mod.Find<ModTile>("IceChest").Type,
                    false,
                    2
                );
            }
        }

        private void GenerateIceBiome(int startX, int startY, int size)
        {
            // Генерация ледяного биома
            for (int x = startX - size; x <= startX + size; x++)
            {
                for (int y = startY - size; y <= startY + size; y++)
                {
                    if (x > 0 && x < Main.maxTilesX && y > 0 && y < Main.maxTilesY)
                    {
                        if (Vector2.Distance(new Vector2(startX, startY), new Vector2(x, y)) <= size)
                        {
                            // Меняем стены
                            if (Main.tile[x, y].WallType == WallID.SnowWallUnsafe)
                            {
                                Main.tile[x, y].WallType = (ushort)Mod.Find<ModWall>("IceWall").Type;
                            }

                            // Меняем блоки
                            if (Main.tile[x, y].TileType == TileID.SnowBlock)
                            {
                                Main.tile[x, y].TileType = (ushort)Mod.Find<ModTile>("IceBlock").Type;
                            }
                            else if (Main.tile[x, y].TileType == TileID.Stone)
                            {
                                Main.tile[x, y].TileType = (ushort)Mod.Find<ModTile>("IceOre").Type;
                            }

                            // Обновляем тайлы
                            WorldGen.SquareTileFrame(x, y);
                        }
                    }
                }
            }

            // Генерация ледяных руд
            for (int k = 0; k < 1000; k++)
            {
                int positionX = WorldGen.genRand.Next(0, Main.maxTilesX);
                int positionY = WorldGen.genRand.Next(0, Main.maxTilesY);
                if (Main.tile[positionX, positionY].TileType == Mod.Find<ModTile>("IceBlock").Type)
                {
                    WorldGen.TileRunner(positionX, positionY, WorldGen.genRand.Next(2, 8), WorldGen.genRand.Next(2, 8), (ushort)Mod.Find<ModTile>("IceOre").Type, false, 0f, 0f, false, true);
                }
            }

            // Генерация очень ледяных блоков на краях
            for (int k = 0; k < Main.maxTilesX; k++)
            {
                for (int i = 0; i < Main.maxTilesY; i++)
                {
                    if (Main.tile[k, i].TileType == Mod.Find<ModTile>("IceBlock").Type)
                    {
                        if (!(Main.tile[k + 1, i].HasTile && Main.tile[k, i - 1].HasTile && Main.tile[k - 1, i].HasTile && Main.tile[k, i + 1].HasTile))
                        {
                            Main.tile[k, i].TileType = (ushort)Mod.Find<ModTile>("VeryVeryIce").Type;
                        }
                    }
                }
            }

            // Генерация данжа в центре ледяного биома
            CreateDungeon(startX, startY, Mod.Find<ModTile>("DungeonBlock").Type, Mod.Find<ModWall>("DungeonWall").Type, Mod.Find<ModTile>("IceChest").Type);

            // Генерация дополнительных структур
            CreateDungeon(startX - 42, startY - 21, Mod.Find<ModTile>("DungeonBlock").Type, Mod.Find<ModWall>("DungeonWall").Type, Mod.Find<ModTile>("IceChest").Type);
            CreateDungeon(startX - 120, startY + 50, Mod.Find<ModTile>("DungeonBlock").Type, Mod.Find<ModWall>("DungeonWall").Type, Mod.Find<ModTile>("IceChest").Type);

        }

        // Этот класс будет представлять предметы в сундуке.
        public class ChestItem
        {
            public int itemType; // Тип предмета
            public int stack;    // Количество предмета

            // Конструктор для инициализации ChestItem
            public ChestItem(int itemType, int stack)
            {
                this.itemType = itemType;
                this.stack = stack;
            }
        }

        private void CreateDungeon(int startX, int startY, ushort dungeonBlock, ushort dungeonWall, ushort iceChest)
        {
            // Найдите файл структуры, который вы хотите использовать для подземелья.
            // Путь к структуре должен быть правильным, и структура должна быть уже создана в вашем проекте.
            string structurePath = "Structures/CreateDungeon";

            // Генерация структуры в нужном месте
            StructureHelper.Generator.GenerateStructure(structurePath, new Point16(startX, startY), TremorMod.Instance);

            // Получение размеров структуры для добавления защиты в мир
            var dims = new Point16();
            StructureHelper.Generator.GetDimensions(structurePath, TremorMod.Instance, ref dims);

            // Генерация сундуков внутри подземелья (если необходимо)
            PlaceDungeonChests(startX, startY, iceChest);
        }

        private void PlaceDungeonChests(int startX, int startY, ushort iceChest)
        {
            // Пример размещения сундуков в подземелье
            int chestOffsetX1 = startX + 5;
            int chestOffsetY1 = startY + 3;
            if (WorldGen.PlaceObject(chestOffsetX1, chestOffsetY1, iceChest))
            {
                WorldGen.SquareTileFrame(chestOffsetX1, chestOffsetY1);
                int chestIndex = Chest.FindChest(chestOffsetX1, chestOffsetY1);
                if (chestIndex >= 0)
                {
                    // Заполняем сундук предметами
                    FillIceChest(Main.chest[chestIndex]);
                }
            }

            int chestOffsetX2 = startX - 6;
            int chestOffsetY2 = startY - 3;
            if (WorldGen.PlaceObject(chestOffsetX2, chestOffsetY2, iceChest))
            {
                WorldGen.SquareTileFrame(chestOffsetX2, chestOffsetY2);
                int chestIndex = Chest.FindChest(chestOffsetX2, chestOffsetY2);
                if (chestIndex >= 0)
                {
                    // Заполняем сундук предметами
                    FillIceChest(Main.chest[chestIndex]);
                }
            }
        }

        public static void FillIceChest(Chest chest)
        {
            // Example random potion selection (you can choose your own potions here)
            int potionType = Utils.SelectRandom(WorldGen.genRand, ItemID.BattlePotion, ItemID.HunterPotion, ItemID.TrapsightPotion);

            // Create a list of items to be placed in the chest
            List<ChestItem> contents = new List<ChestItem>()
            {
                new ChestItem(ModContent.ItemType<FrostLance>(), 1),
                new ChestItem(ModContent.ItemType<FrozenPaxe>(), 1),
                new ChestItem(ModContent.ItemType<FrostGuardian>(), 1),
                new ChestItem(ModContent.ItemType<FrostWind>(), 1),
                new ChestItem(ItemID.GoldCoin, WorldGen.genRand.Next(10, 13)), // Random Gold Coins
                new ChestItem(ItemID.HealingPotion, WorldGen.genRand.Next(5, 10)), // Random healing potions
                new ChestItem(potionType, WorldGen.genRand.Next(5, 10)), // Random potion
            };

            // Loop through and add items to the chest
            for (int i = 0; i < contents.Count; i++)
            {
                if (chest.item[i] == null)
                    chest.item[i] = new Item();

                chest.item[i].SetDefaults(contents[i].itemType);
                chest.item[i].stack = contents[i].stack;
            }
        }



        /*public override void PostWorldGen()
		{
            foreach (Chest chest in Main.chest.Where(c => c != null))
            {
                if (chest != null)
                {
                    var tile = Main.tile[chest.x, chest.y];

                    // Make sure chest is the right type and ready for interaction
                    if (tile.TileType == ModContent.TileType<IceChest>())
                    {
                        // Add items to the chest
                        chest.item[0] = new Item(); // Reset the chest's first item slot if needed
                        chest.item[0].SetDefaults(ModContent.ItemType<FrostLance>());
                        chest.item[1] = new Item();
                        chest.item[1].SetDefaults(ModContent.ItemType<FrozenPaxe>());
                        chest.item[2] = new Item();
                        chest.item[2].SetDefaults(ModContent.ItemType<FrostGuardian>());
                        chest.item[3] = new Item();
                        chest.item[3].SetDefaults(ModContent.ItemType<FrostWind>());

                        // Add some additional random items
                        chest.item[4] = new Item();
                        chest.item[4].SetDefaults(ModContent.ItemType<FrostLiquidFlask>());
                        chest.item[4].stack = WorldGen.genRand.Next(15, 36);

                        // Add coins
                        chest.item[5] = new Item();
                        chest.item[5].SetDefaults(ItemID.GoldCoin);
                        chest.item[5].stack = WorldGen.genRand.Next(10, 13);
                    }
                }
            }
        }


            // Iterate chests
            foreach (Chest chest in Main.chest.Where(c => c != null))
			{
				// Get a chest
				var tile = Main.tile[chest.x, chest.y]; // the chest tile

				// ??
				if (tile.TileType == TileID.Containers
					&& (tile.TileFrameX == 3 * 36 || tile.TileFrameX == 4 * 36)
					&& WorldGen.genRand.NextBool(4))
				{
					foreach (var item in chest.item.Where(x => x != null))
					{
						if (item.type == ItemID.FlyingCarpet || item.type == ItemID.SandstorminaBottle)
						{
							// fixed: replacing flying carpet or sandstorm in a bottle
							chest.AddItem(ModContent.ItemType<HeartAmulet>());
						}
						else if (item.type == ItemID.PharaohsMask)
						{
							// fixed: replacing pharaohs mask
							chest.AddItem(ModContent.ItemType<HeartAmulet>());
							chest.AddItem(ItemID.GoldBar, 5);
						}
					}
				}
				else if (tile.TileType == ModContent.TileType<RuinChest>())
				{
					// fixed: ruin chest replacing
					chest.AddItem(Utils.SelectRandom(WorldGen.genRand, ModContent.ItemType<RustySlasher>(), ModContent.ItemType<FirebenderTome>(),
                        ModContent.ItemType<AntiqueStave>(), ModContent.ItemType<Decayed>()));

					chest.AddItem(Utils.SelectRandom(WorldGen.genRand, ItemID.IronBar, ItemID.TinBar, ItemID.SilverBar,
						ItemID.CopperBar, ItemID.GoldBar, ItemID.PlatinumBar, ItemID.LeadBar, ItemID.TungstenBar,
                        ModContent.ItemType<ArgiteBar>(), ModContent.ItemType<SteelBar>(), ModContent.ItemType<BronzeBar>()),
						Main.rand.Next(8, 14));

					chest.AddItem(ItemID.StrangeBrew, WorldGen.genRand.Next(5, 11));
					chest.AddItem(ItemID.Rope, WorldGen.genRand.Next(50, 101));
					chest.AddItem(ItemID.Bomb, WorldGen.genRand.Next(8, 16));
					chest.AddItem(ItemID.GoldCoin, WorldGen.genRand.Next(1, 4));
				}
				else if (tile.TileType == ModContent.TileType<IceChest>())
				{
					// fixed: ice chest replacing
					chest.AddItem(Utils.SelectRandom(WorldGen.genRand, ModContent.ItemType<FrostLance>(), ModContent.ItemType<FrozenPaxe>(),
                        ModContent.ItemType<FrostGuardian>(), ModContent.ItemType<FrostWind>()));

					chest.AddItem(ModContent.ItemType<FrostLiquidFlask>(), WorldGen.genRand.Next(15, 36));
					chest.AddItem(ItemID.GoldCoin, WorldGen.genRand.Next(10, 13));
				}
			}*/


        public override void ResetNearbyTileEffects()
        {
            TremorPlayer modPlayer = Main.player[Main.myPlayer].GetModPlayer<TremorPlayer>();
            modPlayer.NovaMonolith = false;
        }

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            CometTiles = tileCounts[Mod.Find<ModTile>("CometiteOreTile").Type] + tileCounts[Mod.Find<ModTile>("HardCometiteOreTile").Type];
            GraniteTiles = tileCounts[368] + tileCounts[180];
            RuinsTiles = tileCounts[120];
            IceTiles = tileCounts[Mod.Find<ModTile>("IceBlock").Type] + tileCounts[Mod.Find<ModTile>("IceOre").Type] + tileCounts[Mod.Find<ModTile>("VeryVeryIce").Type] + tileCounts[Mod.Find<ModTile>("DungeonBlock").Type];
        }
    }
}