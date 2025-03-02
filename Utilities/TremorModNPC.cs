using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Chat;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.BossLoot.TikiTotem;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Materials;
using TremorMod.Utilities;
using System.Linq;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader.IO;
using TremorMod.Content.Tiles;
using TremorMod;
using ReLogic.Content;
using TremorMod.Content.NPCs.Bosses.NovaPillar;
using TremorMod.Content.Items;
using TremorMod.Content.NPCs.Bosses.SpaceWhale;
using TremorMod.Content.NPCs.Bosses.Trinity;

namespace TremorMod.Utilities
{
    public partial class TremorModNPC : GlobalNPC
    {
        public override void Load()
        {
            MoonMarkText = Language.GetOrRegister("Mods.TremorMod.MoonMarkText");
            CometSparkleText = Language.GetOrRegister("Mods.TremorMod.CometSparkleText");
        }

        public static LocalizedText MoonMarkText { get; private set; }
        public static LocalizedText CometSparkleText { get; private set; }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.CultistBoss)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<NovaPilarSummon>(), 1, 1, 1));
            }
        }

        private bool IsAreaClear(int startX, int startY, int width, int height)
        {
            for (int x = startX; x < startX + width; x++)
            {
                for (int y = startY; y < startY + height; y++)
                {
                    Tile tile = Framing.GetTileSafely(x, y);
                    if (tile.HasTile && Main.tileSolid[tile.TileType])
                    {
                        return false; 
                    }
                }
            }
            return true; 
        }
        private void GenerateLunarStructure(int x, int y)
        {
            WorldGen.PlaceTile(x, y, TileID.LunarOre);
            WorldGen.PlaceTile(x + 1, y, TileID.LunarOre);
            WorldGen.PlaceTile(x + 2, y, TileID.LunarOre);
            WorldGen.PlaceTile(x + 3, y, TileID.LunarOre);

            WorldGen.PlaceTile(x + 1, y + 1, TileID.LunarOre);
            WorldGen.PlaceTile(x + 2, y + 1, TileID.LunarOre);

            WorldGen.PlaceObject(x + 1, y - 1, ModContent.TileType<LunarRootTile>());
        }
        public override void OnKill(NPC npc)
        {
            if (npc.type == NPCID.MoonLordCore && !TremorMod.HasGeneratedLunarRootTile)
            {
                TremorMod.HasGeneratedLunarRootTile = true;
                Main.NewText("The Moon's power has left its mark...", 73, 0, 92);

                int skyHeight = 100;
                int interval = 100;

                Main.NewText("Nightmares became reality!", 90, 0, 157);
                Main.NewText("The moon slowly drifts towards the Earth...", 0, 255, 255);

                for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
                {
                    int i2 = WorldGen.genRand.Next(0, Main.maxTilesX);
                    int j2 = WorldGen.genRand.Next((int)(Main.maxTilesY * .3f), (int)(Main.maxTilesY * .45f));
                    WorldGen.OreRunner(i2, j2, WorldGen.genRand.Next(3, 4), WorldGen.genRand.Next(3, 8), (ushort)ModContent.TileType<NightmareOreTile>());
                }

                for (int x = interval; x < Main.maxTilesX - interval; x += interval)
                {
                    for (int y = 50; y < skyHeight; y += interval)
                    {
                        if (WorldGen.InWorld(x, y) && IsAreaClear(x, y, 4, 4))
                        {
                            GenerateLunarStructure(x, y);
                        }
                    }
                }
            }
            if (npc.type == ModContent.NPCType<SpaceWhale>() && !TremorModSystem.HasGeneratedCometiteOre)
            {
                TremorModSystem.HasGeneratedCometiteOre = true;

                int worldWidth = Main.maxTilesX;
                int worldHeight = Main.maxTilesY;

                int centerX = WorldGen.genRand.Next(worldWidth / 4, 3 * worldWidth / 4);
                int centerY = WorldGen.genRand.Next(0, worldHeight / 2);

                int radius = 20; 
                int borderThickness = 3; 

                for (int x = -radius - borderThickness; x <= radius + borderThickness; x++)
                {
                    for (int y = -radius - borderThickness; y <= radius + borderThickness; y++)
                    {
                        int tileX = centerX + x;
                        int tileY = centerY + y;
                        if (tileX >= 0 && tileX < worldWidth && tileY >= 0 && tileY < worldHeight)
                        {
                            int distanceSquared = x * x + y * y;
                            if (distanceSquared <= (radius + borderThickness) * (radius + borderThickness) &&
                                distanceSquared > radius * radius)
                            {
                                if (!Main.tile[tileX, tileY].HasTile)
                                {
                                    WorldGen.PlaceTile(tileX, tileY, ModContent.TileType<HardCometiteOreTile>(), true, true);
                                }
                            }
                            else if (distanceSquared <= radius * radius)
                            {
                                if (!Main.tile[tileX, tileY].HasTile)
                                {
                                    WorldGen.PlaceTile(tileX, tileY, ModContent.TileType<CometiteOreTile>(), true, true);
                                }
                            }
                        }
                    }
                }
                Main.NewText("Something sparkles in the sky!", 50, 255, 130);
            }      
        }
    }
}